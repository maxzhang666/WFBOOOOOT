using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;

namespace WFBooooot.IOT.Event
{
    public class EventGroupMessageForward : IGroupMessageEvent
    {
        /// <summary>
        /// 群消息转发
        /// </summary>
        /// <param name="e"></param>
        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (e.FromGroup.Id == 615486489 && e.FromQQ.Id == 2667926680)
            {
                //消息转发
                
            }
        }
    }
}