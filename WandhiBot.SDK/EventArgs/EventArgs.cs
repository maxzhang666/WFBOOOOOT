using WandhiBot.SDK.Enum;

namespace WandhiBot.SDK.EventArgs
{
    /// <summary>
    /// 事件参数
    /// </summary>
    public abstract class EventArgs
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageEventType Type { get; set; }
    }
}