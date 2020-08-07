using System.Threading.Tasks;
using IocManager;
using WandhiBot.SDK.EventArgs;
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
        /// <param name="e"></param>
        void GroupMessage(GroupMessageEventArgs e);
    }
}