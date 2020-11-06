using System.Threading.Tasks;
using IocManager;
using WandhiBot.SDK.EventArgs;
using WandhiBot.SDK.Model;

namespace WandhiBot.SDK.Event
{
    /// <summary>
    /// QQ进群事件
    /// </summary>
    public interface IGroupJoinEvent
    {
        /// <summary>
        /// QQ进群事件
        /// </summary>
        /// <param name="e"></param>
        void GroupJoin(GroupJoinEventArgs e);
    }
}