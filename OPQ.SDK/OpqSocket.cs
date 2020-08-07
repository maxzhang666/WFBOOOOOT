using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using IocManager;
using OPQ.SDK.Enum;
using SocketClient;
using SocketClient.Message;

namespace OPQ.SDK
{
    /// <summary>
    /// OPQ框架Socket连接器
    /// </summary>
    public class OpqSocket
    {
        private Client _socketClient;

        /// <summary>
        /// IOC工具
        /// </summary>
        public IWandhiIocManager WandhiIocManager;

        private Dictionary<EventType, List<Action<IMessage>>> _actions = new Dictionary<EventType, List<Action<IMessage>>>();

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
            _socketClient = new Client(uri);

            InitContainer();
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
        public void On(EventType eventType, Action<IMessage> callback)
        {
            if (_socketClient == null)
            {
                throw new Exception("socket连接未初始化");
            }

            if (_actions.ContainsKey(eventType))
            {
                _actions[eventType].Add(callback);
            }
            else
            {
                _actions.Add(eventType, new List<Action<IMessage>> {callback});
            }

            _socketClient.On(eventType.ToString(), (message) =>
            {
                foreach (var item in _actions[eventType])
                {
                    Task.Factory.StartNew(() => { item.Invoke(message); });
                }
            });
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        private void InitContainer()
        {
            WandhiIocManager = new WandhiWandhiIocManager();
            WandhiIocManager.RegisterByAssemblies(Assembly.GetExecutingAssembly());
        }
    }
}