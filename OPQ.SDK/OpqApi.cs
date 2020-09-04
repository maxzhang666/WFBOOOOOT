using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Timers;
using IocManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OPQ.SDK.Enum;
using OPQ.SDK.Model;
using OPQ.SDK.Model.Group;
using WandhiHelper.Extension;

namespace OPQ.SDK
{
    public class OpqApi
    {
        private string Root { set; get; }
        private long CurrentQQ { set; get; }
        private string Version;
        private int TimeOut;

        /// <summary>
        /// 每秒执行一次，处理发送事件
        /// </summary>
        private Timer _timer = new Timer(TimeSpan.FromMilliseconds(1).TotalMilliseconds);

        /// <summary>
        /// 待发送消息队列
        /// </summary>
        private ConcurrentQueue<Message> _sendActions = new ConcurrentQueue<Message>();

        #region 配置信息

        private JsonSerializerSettings _jsonFormat = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        #endregion

        #region Api地址

        /// <summary>
        /// 通用消息发送
        /// </summary>
        private string SendMsg => $"{Root}/{Version}/LuaApiCaller?qq={CurrentQQ}&funcname=SendMsg&timeout={TimeOut}";

        #endregion

        /// <summary>
        /// 初始化Api
        /// </summary>
        /// <param name="root">
        /// 机器人服务根地址
        /// ep:http://127.0.0.1:8888
        /// </param>
        /// <param name="currentQQ">
        /// 机器人QQ
        /// </param>
        /// <param name="version">
        /// 机器人Api版本号，默认V1
        /// </param>
        /// <param name="timeout">
        /// 超时时间
        /// </param>
        public OpqApi(string root, long currentQQ, string version = "v1", int timeout = 10)
        {
            Root = root;
            CurrentQQ = currentQQ;
            Version = version;
            TimeOut = timeout;


            _timer.Elapsed += (s, e) => MsgProcess();
            _timer.Start();
        }

        #region 群消息发送

        /// <summary>
        /// 发送群文字消息
        /// </summary>
        public void SendMessage(Message message)
        {
            if (message.SendMsgType == MessageType.TextMsg)
            {
                if (!message.Content.IsEmpty())
                {
                    _sendActions.Enqueue(message);
                }
            }
            else
            {
                _sendActions.Enqueue(message);
            }
        }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="to"></param>
        /// <param name="msg"></param>
        public void SendGroupMessage(long to, string msg)
        {
            SendMessage(new GroupMessage(to, msg));
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        private void MsgProcess()
        {
            if (_sendActions.TryDequeue(out var msg))
            {
                Task.Run((() => GHttpHelper.Http.PostJson(SendMsg, JsonConvert.SerializeObject(msg, _jsonFormat))));
            }
        }

        #endregion
    }
}