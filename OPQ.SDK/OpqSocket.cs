using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IocManager;
using OPQ.SDK.Enum;
using SocketClient;
using SocketClient.Message;
using Unity;
using WandhiBot.SDK.Event;

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
        public Client SocketClient { get; private set; }

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
        public OpqSocket(string host, string port, string qq)
        {
            var uri = host.IndexOf("http", StringComparison.Ordinal) > -1
                ? $"{host}:{port}/"
                : $"http://{host}:{port}/";
            SocketClient = new Client(uri);

            //初始化依赖
            InitContainer();
            //注册事件
            RegisterEvent();
            //注册连接持久器
            HoldConnect();
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
            if (SocketClient == null)
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

            SocketClient.On(eventType.ToString(), (message) =>
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
        private OpqSocket InitContainer()
        {
            WandhiIocManager = new WandhiWandhiIocManager();
            WandhiIocManager.RegisterByAssemblies(Assembly.GetExecutingAssembly());

            return this;
        }

        /// <summary>
        /// 注册消息
        /// </summary>
        /// <returns></returns>
        private OpqSocket RegisterEvent()
        {
            //注册群消息事件
            var groupEvent = Assembly.GetExecutingAssembly().GetTypes().Where(e => e.GetInterfaces().Contains(typeof(IGroupMessageEvent)));
            foreach (var item in groupEvent)
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
                SocketClient.Emit("GetWebConn", _qq, null, (callback) =>
                    {
                        if (!(callback is string jsonMsg) || jsonMsg.Contains("OK"))
                        {
                            return;
                        }

                        SocketClient.Close();
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
            if (SocketClient == null)
            {
                throw new Exception("Socket连接未初始化");
            }

            SocketClient.Connect();

            return this;
        }
    }
}