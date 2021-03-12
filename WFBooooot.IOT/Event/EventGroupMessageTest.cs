using System;
using OPQ.SDK;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;

namespace WFBooooot.IOT.Event
{
    public class EventGroupMessageTest : IGroupMessageEvent
    {
        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (e.FromQQ == "373884384" && e.Msg.Text.Contains("撤回我"))
            {
                AppData.OpqApi.SendGroupMessage(e.FromGroup, "好嘞，5秒后撤回你");
                AppData.OpqApi.LazyEvent(new EventLazyRevoke(e.FromGroup, e.Msg, DateTime.Now.AddSeconds(5)));
            }
        }
    }
}