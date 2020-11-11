using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;

namespace WFBooooot.IOT.Event
{
    public class EventGroupMessageHelper : IGroupMessageEvent
    {
        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (e.Msg.Text.StartsWith("/帮助") && AppData.AppConfig.DebugGroup.Contains(e.FromGroup))
            {
                const string msg = @"可以用下列命令调戏我
/查询
/警报
/紫卡
/奸商
/电波
/来张色图
舔狗
";
                AppData.OpqApi.SendGroupMessage(e.FromGroup, msg);
            }
        }
    }
}