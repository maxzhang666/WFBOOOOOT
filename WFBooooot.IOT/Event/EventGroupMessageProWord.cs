using System.Threading.Tasks;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;

namespace WFBooooot.IOT.Event
{
    /// <summary>
    /// 黑话群事件
    /// </summary>
    public class EventGroupMessageProWord : IGroupMessageEvent
    {
        private readonly ConfigService _configService;
        private Log _log;

        public EventGroupMessageProWord(ConfigService configService, Log log)
        {
            _configService = configService;
            _log = log;
        }

        public void GroupMessage(GroupMessageEventArgs e)
        {
            _log.Debug($"黑话群消息:{e.Msg}");
            if (_configService.AppConfig.DebugGroup.Contains(e.FromGroup) && e.Msg.ToString().ToLower().StartsWith("/黑话"))
            {
                // e.CQApi.SendGroupMessage(e.FromGroup, "为萌新送上术语黑话：https://gitee.com/ixysy/WFBOOOOOT/blob/master/%E8%90%8C%E6%96%B0%E6%9C%AF%E8%AF%AD%E5%85%A5%E9%97%A8.md");     
            }
        }
    }
}