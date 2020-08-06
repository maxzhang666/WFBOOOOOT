using IocManager;
using WandhiBot.SDK.EventArgs;
using WandhiBot.SDK.Model;

namespace WandhiBot.SDK.Event
{
    /// <summary>
    /// QQ群消息事件
    /// </summary>
    public interface IGroupMessageEvent:IIocService
    {
        /// <summary>
        /// QQ群消息事件
        /// </summary>
        /// <param name="groupMessageEventArgs"></param>
        void GroupMessage(GroupMessageEventArgs groupMessageEventArgs);
    }
}