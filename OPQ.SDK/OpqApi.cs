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
using WandhiBot.SDK.Model;
using WandhiHelper.Extension;

namespace OPQ.SDK
{
    public class OpqApi
    {
        private string Root { set; get; }
        private long CurrentQq { set; get; }
        private readonly string _version;
        private readonly int _timeOut;

        /// <summary>
        /// 每秒执行一次，处理发送事件
        /// </summary>
        private readonly Timer _timer = new Timer(TimeSpan.FromMilliseconds(1).TotalMilliseconds);

        /// <summary>
        /// 待发送消息队列
        /// </summary>
        private readonly ConcurrentQueue<Message> _sendActions = new ConcurrentQueue<Message>();

        /// <summary>
        /// 定时事件
        /// </summary>
        private readonly ConcurrentQueue<ILazyEvent> _commonQueue = new ConcurrentQueue<ILazyEvent>();

        #region 配置信息

        private readonly JsonSerializerSettings _jsonFormat = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        #endregion

        #region Api地址

        /// <summary>
        /// 通用消息发送
        /// </summary>
        private string SendMsg => $"{Root}/{_version}/LuaApiCaller?qq={CurrentQq}&funcname=SendMsg&timeout={_timeOut}";

        //${host}/v1/LuaApiCaller?qq=${CurrentQQ}&funcname=RevokeMsg&timeout=10
        private string RevokeMsg => $"{Root}/{_version}/LuaApiCaller?qq={CurrentQq}&funcname=RevokeMsg&timeout={_timeOut}";
        private string GroupMgr => $"{Root}/{_version}/LuaApiCaller?qq={CurrentQq}&funcname=GroupMgr&timeout={_timeOut}";

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
            CurrentQq = currentQQ;
            _version = version;
            _timeOut = timeout;


            _timer.Elapsed += (s, e) => MsgProcess();
            _timer.Elapsed += (s, e) => EventProcess();
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
        /// 发送群消息
        /// </summary>
        /// <param name="to"></param>
        /// <param name="msg"></param>
        /// <param name="atUser"></param>
        public void SendGroupMessage(long to, string msg, long atUser)
        {
            SendMessage(new GroupMessage(to, msg, atUser));
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        private void MsgProcess()
        {
            if (!_sendActions.TryDequeue(out var msg))
            {
                return;
            }

            var json = JsonConvert.SerializeObject(msg, _jsonFormat);
            Task.Run((() => GHttpHelper.Http.PostJson(SendMsg, json)));
        }

        #endregion

        #region 撤回消息

        /// <summary>
        /// 撤回群消息
        /// </summary>
        /// <param name="fromGroup"></param>
        /// <param name="msgSeq"></param>
        /// <param name="msgRandom"></param>
        public void RevokeMessage(long fromGroup, long msgSeq, long msgRandom)
        {
            Task.Run(() =>
            {
                GHttpHelper.Http.PostJson(RevokeMsg, JsonConvert.SerializeObject(new
                {
                    GroupID = fromGroup,
                    MsgSeq = msgSeq,
                    MsgRandom = msgRandom
                }));
            });
        }

        /// <summary>
        /// 撤回群消息
        /// </summary>
        /// <param name="fromGroup"></param>
        /// <param name="msg"></param>
        public void RevokeMessage(long fromGroup, QQMessage msg)
        {
            RevokeMessage(fromGroup, msg.MsgSeq, msg.MsgRandom);
        }

        #endregion

        #region 延时事件

        public void LazyEvent(ILazyEvent lazyEvent)
        {
            _commonQueue.Enqueue(lazyEvent);
        }

        private void EventProcess()
        {
            if (_commonQueue.IsEmpty)
            {
                return;
            }

            if (_commonQueue.TryDequeue(out var item))
            {
                Task.Run(() =>
                {
                    if (item.CanDo())
                    {
                        item.Do();
                    }
                    else
                    {
                        _commonQueue.Enqueue(item);
                    }
                });
            }
        }

        #endregion

        #region 群功能

        /// <summary>
        /// 群功能
        /// </summary>
        /// <param name="fromGroup"></param>
        /// <param name="qq"></param>
        /// <param name="msg"></param>
        /// <param name="actionType"></param>
        public void GroupEvent(long fromGroup, long qq, string msg, GroupEvent actionType)
        {
            Task.Run((() =>
            {
                GHttpHelper.Http.PostJson(GroupMgr, JsonConvert.SerializeObject(new
                {
                    ActionType = actionType,
                    GroupID = fromGroup,
                    ActionUserID = qq,
                    Content = msg
                }));
            }));
        }

        #endregion
    }
}