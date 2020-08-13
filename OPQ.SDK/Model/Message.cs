using OPQ.SDK.Enum;

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
        /// 内容
        /// </summary>
        public string Content { set; get; }
        /// <summary>
        /// 群Id
        /// </summary>
        public long Groupid { get; set; }
        /// <summary>
        /// 艾特对象
        /// </summary>
        public long AtUser { set; get; }
        
        
        public Message(long to,string content)
        {
            ToUser = to;
            Content = content;
            SendToType = SendToType.Friend; 
        }
    }
}