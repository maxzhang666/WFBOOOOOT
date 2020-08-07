using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IocManager;
using Newtonsoft.Json;
using SocketClient;
using SocketClient.Message.Impl;
using Unity;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WandhiBot.SDK.Model;
using WFBooooot.IOT.Enum;
using WFBooooot.IOT.Helper;
using WFBooooot.IOT.Model;

namespace WFBooooot.IOT
{
    class Program
    {
        private static ConfigService _ConfigService;
        private static Log _Log;
        private static IWandhiIocManager _WandhiIocManager;
        private static ISocketClient _Socket;
        private static SocketHelper _SocketHelper;

        static void Main(string[] args)
        {
            //初始化依赖
            Init();
            //初始化Socket连接
            SocketInti();


            Hold();
        }

        static void SocketInti()
        {
            var uri = _ConfigService.AppConfig.Host.IndexOf("http", StringComparison.Ordinal) > -1
                ? $"{_ConfigService.AppConfig.Host}:{_ConfigService.AppConfig.Port}/"
                : $"http://{_ConfigService.AppConfig.Host}:{_ConfigService.AppConfig.Port}/";
            _Socket = new SocketClient.SocketClient(uri);

            _Socket.Opened += _SocketHelper.OnSocketConnected;
            _Socket.Message += _SocketHelper.OnSocketMessage;
            _Socket.SocketConnectionClosed += _SocketHelper.OnSocketConnectionClosed;
            _Socket.Error += _SocketHelper.OnSocketError;
            _Socket.Connect();

            _Socket.On("connect", (fn) =>
            {
                Console.WriteLine(((ConnectMessage) fn).ConnectMsg);
                //重连成功 取得 在线QQ的websocket 链接connid
                //Ack
                _Socket.Emit("GetWebConn", _ConfigService.AppConfig.QQ, null, (callback) =>
                    {
                        var jsonMsg = callback as string;
                        Console.WriteLine($"callback [root].[messageAck]: {jsonMsg} \r\n");
                        if (jsonMsg != null && !jsonMsg.Contains("OK"))
                        {
                            //处理有些时候掉线收不到某些消息的问题，重新连接可以解决
                            _Socket.Close();
                            SocketInti();
                            return;
                        }
                    }
                );
            });


            //region 事件分发
            //群消息事件
            _Socket.On(EventType.OnGroupMsgs.ToString(), (message) =>
            {
                var events = _WandhiIocManager.ResolveAll<IGroupMessageEvent>();
                var groupMessage = JsonConvert.DeserializeObject<OpqMessage>(message.MessageText);
                var groupArgs = new GroupMessageEventArgs
                {
                    FromGroup = new Group
                    {
                        Id = groupMessage.CurrentPacket.Data.FromGroupId,
                        GroupName = groupMessage.CurrentPacket.Data.FromGroupName
                    },
                    FromQQ = new QQ
                    {
                        Id = groupMessage.CurrentPacket.Data.FromUserId,
                        NickName = groupMessage.CurrentPacket.Data.FromNickName,
                    },
                    Msg = new QQMessage
                    {
                        Text = groupMessage.CurrentPacket.Data.Content,
                        MsgId = groupMessage.CurrentPacket.Data.MsgSeq
                    }
                };
                foreach (var item in events)
                {
                    Task.Factory.StartNew((() => { item.GroupMessage(groupArgs); }));
                }
            });

            //endregion


            //二维码检测事件
            _Socket.On("OnCheckLoginQrcode",
                (fn) => { Console.WriteLine("OnCheckLoginQrcode\n" + ((JSONMessage) fn).MessageText); });
            //收到好友消息的回调事件
            _Socket.On("OnFriendMsgs",
                (fn) => { Console.WriteLine("OnFriendMsgs\n" + ((JSONMessage) fn).MessageText); });


            //统一事件管理如好友进群事件 好友请求事件 退群等事件集合
            _Socket.On("OnEvents", (fn) => { Console.WriteLine("OnEnevts\n" + ((JSONMessage) fn).MessageText); });
        }

        static void Hold()
        {
            while (true)
            {
                var key = Console.ReadLine();
                if (key.ToLower() == "exit")
                {
                    break;
                }
            }
        }

        static void Init()
        {
            //注册容器
            _WandhiIocManager = new WandhiWandhiIocManager();
            _WandhiIocManager.RegisterByAssemblies(Assembly.GetExecutingAssembly());

            //初始化组件
            _ConfigService = _WandhiIocManager.Resolve<ConfigService>();
            _SocketHelper = _WandhiIocManager.Resolve<SocketHelper>();
            _Log = _WandhiIocManager.Resolve<Log>();

            //注册群消息事件
            var groupEvent = Assembly.GetExecutingAssembly().GetTypes().Where(e => e.GetInterfaces().Contains(typeof(IGroupMessageEvent)));
            foreach (var item in groupEvent)
            {
                _WandhiIocManager.GetContainer().RegisterType(typeof(IGroupMessageEvent), item, item.Name);
            }
        }
    }
}