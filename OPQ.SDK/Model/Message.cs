using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OPQ.SDK.Enum;
using WandhiHelper.Extension;

namespace OPQ.SDK.Model
{
    public class Message
    {
        /// <summary>
        /// 接收用户
        /// </summary>
        public long ToUser { get; set; }

        /// <summary>
        /// 消息发送类型
        /// </summary>
        public SendToType SendToType { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType SendMsgType { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set => _Content = value;
            get
            {
                if (!_Content.IsEmpty())
                {
                    return _Content;
                }

                if (MsgProcess != null)
                {
                    return MsgProcess.Invoke();
                }

                return "";
            }
        }

        private string _Content { set; get; }
        private Func<string> MsgProcess { set; get; }

        /// <summary>
        /// 群Id
        /// </summary>
        public long Groupid { get; set; }

        /// <summary>
        /// 艾特对象
        /// </summary>
        public long AtUser { set; get; }


        public Message(long to, string content)
        {
            ToUser = to;
            Content = content;
            SendToType = SendToType.Friend;
            SendMsgType = MessageType.TextMsg;
        }

        public Message(long to, Func<string> msgProcess)
        {
            ToUser = to;
            MsgProcess = msgProcess;
            SendToType = SendToType.Friend;
            SendMsgType = MessageType.TextMsg;
        }
    }
}