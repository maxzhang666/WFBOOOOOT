using OPQ.SDK.Model.Group;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Extension;

namespace WFBooooot.IOT.Event
{
    /// <summary>
    /// 关键字词库
    /// </summary>
    public class EventGroupMessageKeywords : IGroupMessageEvent
    {
        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (AppData.AppConfig.KeywordConfig.Groups.Contains(e.FromGroup))
            {
                var msg = "";
                foreach (var key in AppData.AppConfig.KeywordConfig.KeyWords.Keys)
                {
                    if (e.Msg.Text.Contains(key))
                    {
                        msg = AppData.AppConfig.KeywordConfig.KeyWords[key];
                        break;
                    }
                }

                if (msg.IsNotEmpty())
                {
                    AppData.OpqApi.SendGroupMessage(e.FromGroup, msg, e.FromQQ);
                }
            }
        }
    }
}