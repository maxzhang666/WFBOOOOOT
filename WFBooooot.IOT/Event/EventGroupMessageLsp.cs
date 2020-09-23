using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            AppData.Log.Info($"LSP日志：{e.FromGroup},{(JsonConvert.SerializeObject(AppData.AppConfig.DebugGroup))}");
            if (AppData.AppConfig.DebugGroup.Contains(e.FromGroup))
            {
                if (e.Msg.Text.StartsWith("/"))
                {
                    var key = e.Msg.Text.Substring(1);
                    if (key.Contains("来张色图"))
                    {
                        AppData.OpqApi.SendGroupMessage(e.FromGroup, "好嘞，马上就给你");
                        var flag = e.FromQQ == 373884384 && (key.Contains("18") || key.Contains("牛批"));
                        AppData.OpqApi.SendMessage(new GroupImgMessage(e.FromGroup, "\r\n收好了您，哎~慢走", GetPicUrl(flag)));
                    }
                }
            }
        }

        /// <summary>
        /// 获取图片地址
        /// </summary>
        /// <param name="isR18">是否获取R18</param>
        /// <returns></returns>
        private string GetPicUrl(bool isR18 = false)
        {
            var res = GHttpHelper.Http.Get<Lsp>($"https://api.lolicon.app/setu/?apikey=071046145f51a2a084d2c5&r18={(isR18 ? "1" : "0")}");
            return res.data.FirstOrDefault().url;
        }
    }
}