using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;

namespace WFBooooot.IOT.Event
{
    /// <summary>
    /// wiki查询群事件
    /// </summary>
    public class EventGroupMessageWiki : IGroupMessageEvent
    {
        public void GroupMessage(GroupMessageEventArgs e)
        {
            // if ((e.FromGroup == AppData.GroupNumber || e.FromGroup == AppData.GroupDebug) && e.Message.Text.ToLower().StartsWith("/wiki"))
            // {
            //     e.CQApi.SendGroupMessage(e.FromGroup, "好嘞，这就去查！");
            //     //e.Handler = true;
            //
            //     var service = new WikiService(e.FromGroup, e.FromQQ, e.Message.Text.Replace("/wiki", "").Replace("/Wiki", "").Trim());
            //     service.send();
            // }
        }
    }
}
