using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;

namespace WFBooooot.IOT.Event
{
    public class EventGroupWelcome:IGroupJoinEvent
    {
        public void GroupJoin(GroupJoinEventArgs e)
        {
            if (AppData.AppConfig.KeywordConfig.Groups.Contains(e.FromGroup))
            {
                AppData.OpqApi.SendGroupMessage(e.FromGroup,"插件食用问题请先查看公告信息，有不明白或不懂请群内艾特 “明天会更好”");
            }
        }
    }
}