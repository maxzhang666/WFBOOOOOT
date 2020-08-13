using OPQ.SDK.Enum;

namespace OPQ.SDK.Model
{
    public class QMessage
    {
        /// <summary>
        /// 来源群
        /// </summary>
        public int FromGroupId { get; set; }

        /// <summary>
        /// 来源群名称
        /// </summary>
        public string FromGroupName { get; set; }

        /// <summary>
        /// 来源用户
        /// </summary>
        public int FromUserId { get; set; }

        /// <summary>
        /// 来源用户名称
        /// </summary>
        public string FromNickName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType MsgType { get; set; }

        /// <summary>
        /// 消息事件戳
        /// </summary>
        public long MsgTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MsgSeq { get; set; }

        /// <summary>
        /// 消息随机值
        /// </summary>
        public long MsgRandom { get; set; }

        /// <summary>
        /// 红包信息
        /// </summary>
        public string RedBaginfo { get; set; }
    }
}