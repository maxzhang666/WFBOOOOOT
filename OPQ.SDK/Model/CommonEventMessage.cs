using OPQ.SDK.Enum;

namespace OPQ.SDK.Model
{
    public class CommonEventMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public CommonEventData EventData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CommonEventMsg EventMsg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CommonEventType EventName { get; set; }
    }

    public class CommonEventData
    {
        /// <summary>
        /// 
        /// </summary>
        public long InviteUin { get; set; }

        /// <summary>
        /// 事件产生源
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 事件产生源昵称
        /// </summary>
        public string UserName { get; set; }
    }


    public class CommonEventMsg
    {
        /// <summary>
        /// 事件接受方
        /// </summary>
        public long FromUin { get; set; }

        /// <summary>
        /// 事件源
        /// </summary>
        public long ToUin { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public CommonEventType MsgType { get; set; }

        /// <summary>
        /// 消息索引
        /// </summary>
        public long MsgSeq { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 红包
        /// </summary>
        public string RedBaginfo { get; set; }
    }
}