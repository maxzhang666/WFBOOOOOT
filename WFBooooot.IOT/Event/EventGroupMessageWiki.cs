using OPQ.SDK;
using OPQ.SDK.Model.Group;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Model;

namespace WFBooooot.IOT.Event
{
    /// <summary>
    /// wiki查询群事件
    /// </summary>
    public class EventGroupMessageWiki : IGroupMessageEvent
    {
        private OpqApi _opqApi;

        public EventGroupMessageWiki(OpqApi opqApi)
        {
            _opqApi = opqApi;
        }

        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (AppData.AppConfig.DebugGroup.Contains(e.FromGroup) && e.Msg.Text.ToLower().StartsWith("/wiki"))
            {
                _opqApi.SendMessage(new GroupMessage(e.FromGroup, "好嘞，这就去查！"));
                //e.Handler = true;

                // var service = new WikiService(e.FromGroup, e.FromQQ, e.Message.Text.Replace("/wiki", "").Replace("/Wiki", "").Trim());
                // service.send();
            }
        }
    }
}