using WandhiBot.SDK.Model;

namespace WandhiBot.SDK.Event
{
    /// <summary>
    /// QQ群消息事件
    /// </summary>
    public interface IGroupMessageEvent
    {
        /// <summary>
        /// QQ群消息事件
        /// </summary>
        /// <param name="fromQQ">来源QQ</param>
        /// <param name="fromGroup">来源群</param>
        /// <param name="msg">消息内容</param>
        void GroupMessage(string fromQQ, string fromGroup, QQMessage msg);
    }
}