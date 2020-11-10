using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Service;

namespace WFBooooot.IOT.Event
{
    public class EventGroupMessageDog : IGroupMessageEvent
    {
        public void GroupMessage(GroupMessageEventArgs e)
        {
            var msg = new DogService(e.FromGroup).GetMsg();
            if (msg.IsNotEmpty())
            {
                AppData.OpqApi.SendGroupMessage(e.FromGroup, msg);
            }
        }
    }
}