using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IocManager;
using Newtonsoft.Json;
using OPQ.SDK.Enum;
using OPQ.SDK.Model;
using SocketClient;
using SocketClient.Message;
using Unity;
using Unity.Injection;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WandhiBot.SDK.Model;

namespace OPQ.SDK
{
    /// <summary>
    /// OPQ框架Socket连接器
    /// </summary>
    public class OpqSocket
    {
        /// <summary>
        /// 放开Socket连接客户端以便自行debug连接异常 
        /// </summary>
        public Client Client { get; private set; }

        private Log _log { set; get; }

        /// <summary>
        /// IOC工具
        /// </summary>
        public IWandhiIocManager WandhiIocManager;

        private Dictionary<EventType, List<Action<IMessage>>> _actions = new Dictionary<EventType, List<Action<IMessage>>>();
        private string _qq;
        private string _host;
        private string _port;

        /// <summary>
        /// 初始化OpqSocket连接
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="qq"></param>
        /// <param name="assembly"></param>
        /// <param name="wandhiIocManager">容器</param>
        public OpqSocket(string host, string port, string qq, Assembly[] assembly, IWandhiIocManager wandhiIocManager)
        {
            _qq = qq;
            _host = host.IndexOf("http", StringComparison.Ordinal) > -1 ? $"{host}" : $"http://{host}";
            _port = $"{port}";
            var uri = $"{_host}:{_port}/";
            Client = new Client(uri);

            WandhiIocManager = wandhiIocManager;

            //初始化依赖
            InitContainer(assembly);
            //注册事件
            RegisterEvent(assembly);
            //注册连接持久器
            HoldConnect();
            //事件分发
            EventOutGiving();
        }

        /// <summary>
        /// 初始化OpqSocket连接
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="qq"></param>
        /// <param name="assembly"></param>
        /// <param name="wandhiIocManager">容器</param>
        /// <param name="assemblyAssemblies"></param>
        public OpqSocket(string host, string port, string qq, Assembly[] assemblyAssemblies)
        {
            _qq = qq;
            _host = host.IndexOf("http", StringComparison.Ordinal) > -1 ? $"{host}" : $"http://{host}";
            _port = $"{port}";
            var uri = $"{_host}:{_port}/";
            Client = new Client(uri);
            //初始化依赖
            InitContainer(assemblyAssemblies);
            //注册事件
            RegisterEvent(assemblyAssemblies);
            //注册连接持久器
            HoldConnect();
            //事件分发
            EventOutGiving();
        }

        private void EventOutGiving()
        {
            #region 事件分发

            //endregion 群消息事件
            On(EventType.OnGroupMsgs, (message) =>
            {
                var groupMessage = JsonConvert.DeserializeObject<OpqMessage>(message.MessageText);
                _log.Info(
                    $"消息：类型[群],来源[{groupMessage.CurrentPacket.Data.FromGroupId}],用户[{groupMessage.CurrentPacket.Data.FromNickName}--{groupMessage.CurrentPacket.Data.FromUserId}]:{groupMessage.CurrentPacket.Data.Content}");

                //忽略自己的消息
                if (groupMessage.CurrentPacket.Data.FromUserId != long.Parse(_qq))
                {
                    var events = WandhiIocManager.ResolveAll<IGroupMessageEvent>();
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
                }
            });

            #endregion
        }

        /// <summary>
        /// 监听Socket事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="callback">
        /// 回调事件
        /// 回调事件接受最原始的数据信息
        /// 请自行处理
        /// </param>
        /// <exception cref="Exception"></exception>
        public OpqSocket On(EventType eventType, Action<IMessage> callback)
        {
            if (Client == null)
            {
                throw new Exception("socket连接未初始化");
            }

            if (_actions.ContainsKey(eventType))
            {
                //确保事件列表中每个响应事件有且仅有一个
                if (!_actions[eventType].Contains(callback))
                {
                    _actions[eventType].Add(callback);
                }
            }
            else
            {
                _actions.Add(eventType, new List<Action<IMessage>> {callback});
            }

            Client.On(eventType.ToString(), (message) =>
            {
                foreach (var item in _actions[eventType])
                {
                    Task.Factory.StartNew(() => { item.Invoke(message); });
                }
            });

            return this;
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        private OpqSocket InitContainer(Assembly[] assemblyAssemblies)
        {
            if (WandhiIocManager == null)
            {
                WandhiIocManager = new WandhiWandhiIocManager();
            }

            WandhiIocManager.RegisterByAssemblies(assemblyAssemblies);

            //注册Api操作类
            WandhiIocManager.GetContainer().RegisterSingleton<OpqApi>(new InjectionConstructor($"{_host}:{_port}", long.Parse(_qq), "v1", 10));
            _log = WandhiIocManager.Resolve<Log>();

            return this;
        }

        /// <summary>
        /// 注册消息响应事件
        /// </summary>
        /// <returns></returns>
        private OpqSocket RegisterEvent(Assembly[] assemblyAssemblies)
        {
            //注册群消息响应事件
            var groupEvents = new List<Type>();
            foreach (var assembly in assemblyAssemblies)
            {
                groupEvents.AddRange(assembly.GetTypes().Where(e => e.GetInterfaces().Contains(typeof(IGroupMessageEvent))));
            }

            foreach (var item in groupEvents)
            {
                WandhiIocManager.GetContainer().RegisterType(typeof(IGroupMessageEvent), item, item.Name);
            }


            return this;
        }

        /// <summary>
        /// 处理有些时候掉线收不到某些消息的问题，重新连接可以解决
        /// </summary>
        private void HoldConnect()
        {
            On(EventType.connect, (fn) =>
            {
                Client.Emit("GetWebConn", _qq, null, (callback) =>
                    {
                        if (!(callback is string jsonMsg) || jsonMsg.Contains("OK"))
                        {
                            return;
                        }

                        Client.Close();
                        Connect();
                    }
                );
            });
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public OpqSocket Connect()
        {
            if (Client == null)
            {
                throw new Exception("Socket连接未初始化");
            }

            Client.Connect();

            return this;
        }
    }
}