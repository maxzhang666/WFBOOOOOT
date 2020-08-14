using OPQ.SDK.Model.Group;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Service;

namespace WFBooooot.IOT.Event
{
    public class EventGroupMessageWarframe : IGroupMessageEvent
    {
        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (e.Msg.Text.StartsWith("/"))
            {
                var warframe = new WarframeInfoService(e.FromGroup, e.FromQQ, e.Msg.Text.Substring(1));
                var msg = warframe.GetMsg(e.Msg.Text.Substring(1));
                AppData.OpqApi.SendMessage(new GroupMessage(e.FromGroup, msg));
            }
        }
    }
}