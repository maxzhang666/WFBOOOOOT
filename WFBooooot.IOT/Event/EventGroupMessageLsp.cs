using System.Linq;
using OPQ.SDK.Model.Group;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Model.Lsp;

namespace WFBooooot.IOT.Event
{
    /// <summary>
    /// LSP 来张色图
    /// </summary>
    public class EventGroupMessageLsp : IGroupMessageEvent
    {
        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (AppData.AppConfig.DebugGroup.Contains(e.FromGroup))
            {
                if (e.Msg.Text.StartsWith("/"))
                {
                    var key = e.Msg.Text.Substring(1);
                    if (key.Contains("来张色图"))
                    {
                        AppData.OpqApi.SendGroupMessage(e.FromGroup, "好嘞，马上就给你");
                        AppData.OpqApi.SendMessage(new GroupImgMessage(e.FromGroup, "\r\n收好了您，哎~慢走", GetPicUrl()));
                    }
                }
            }
        }

        private string GetPicUrl()
        {
            var res = GHttpHelper.Http.Get<Lsp>("https://api.lolicon.app/setu/?apikey=071046145f51a2a084d2c5");
            return res.data.FirstOrDefault().url;
        }
    }
}