using System;
using System.Text.RegularExpressions;
using WandhiBot.SDK.Enum;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Extension;

namespace WFBooooot.IOT.Event
{
    public class GroupTaoLink :IGroupMessageEvent
    {
        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (e.FromGroup==937826612||e.FromGroup==1019480370)
            {
                var reg = new Regex(@"https:\/\/m\.tb\.cn\/[a-zA-Z.0-9?=&]*",RegexOptions.IgnoreCase);
                if (reg.IsMatch(e.Msg))
                {
                    var link = reg.Match(e.Msg);
                    var linkStr = link?.Value;
                    
                    AppData.OpqApi.SendGroupMessage(e.FromGroup,$"来了老弟:{linkStr}&fpChannel=9 {e.FromQQ.AtUser()}");
                }
            }
        }
    }
}