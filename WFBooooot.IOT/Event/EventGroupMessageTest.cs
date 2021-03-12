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
                AppData.OpqApi.RevokeMessage(e.FromGroup, e.Msg);
            }
        }
    }
}