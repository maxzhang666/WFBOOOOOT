using System;
using System.Linq;
using System.Text;
using GHttpHelper;
using OPQ.SDK.Model.Group;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Helper;
using WFBooooot.IOT.Model.Lsp;

namespace WFBooooot.IOT.Event
{
    /// <summary>
    /// LSP 来张色图
    /// </summary>
    public class EventGroupMessageLsp : IGroupMessageEvent
    {
        private CacheHelper _cacheHelper;

        public EventGroupMessageLsp(CacheHelper cacheHelper)
        {
            _cacheHelper = cacheHelper;
        }

        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (!AppData.AppConfig.DebugGroup.Contains(e.FromGroup))
            {
                return;
            }

            if (!e.Msg.Text.StartsWith("/"))
            {
                return;
            }

            var key = e.Msg.Text.Substring(1);
            if (!key.Contains("来张色图"))
            {
                return;
            }

            var lastTime = _cacheHelper.Get("lsp", DateTime.Now - TimeSpan.FromMinutes(1));
            if (DateTime.Now - lastTime > TimeSpan.FromMinutes(1))
            {
                _cacheHelper.Set("lsp", DateTime.Now);
                AppData.OpqApi.SendGroupMessage(e.FromGroup, "好嘞，马上就给你");
                var flag = e.FromQQ == 373884384 && (key.Contains("18") || key.Contains("牛批"));
                var data = LspCount(e.FromQQ);
                if (data != null)
                {
                    var p = Math.Round(data.info.sp_count / data.count, 4, MidpointRounding.AwayFromZero);
                    AppData.OpqApi.SendMessage(new GroupImgMessage(e.FromGroup, $"\r\n收好了您，哎~慢走\r\n你的涩批指数：【{p * 100}%】", GetPicUrl(flag)));
                }
                else
                {
                    AppData.OpqApi.SendMessage(new GroupImgMessage(e.FromGroup, "\r\n收好了您，哎~慢走", GetPicUrl(flag)));
                }
            }
            else
            {
                var data = LspCdCount(e.FromQQ);
                if (data != null)
                {
                    var p = Math.Round(data.info.sp_cd_count / data.cd_count, 4, MidpointRounding.AwayFromZero);
                    AppData.OpqApi.SendGroupMessage(e.FromGroup, $"这么快就冲完了？缓缓吧+\r\n+饥渴指数：【{p * 100}%】");
                }
                else
                {
                    AppData.OpqApi.SendGroupMessage(e.FromGroup, "这么快就冲完了？缓缓吧");
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
            return res.data.FirstOrDefault()?.url;
        }

        /// <summary>
        /// lsp统计
        /// </summary>
        /// <param name="qq"></param>
        private LspData LspCdCount(string qq)
        {
            var res = Http.Post<LspAnalyze>("https://api.wandhi.com/api/tools/lsp", new {qq = qq, cd = true}, RequestType.Json, "");
            return res.code == 1 ? res.data : null;
        }

        /// <summary>
        /// lsp普通统计
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        private LspData LspCount(string qq)
        {
            var res = Http.Post<LspAnalyze>("https://api.wandhi.com/api/tools/lsp", new {qq = qq, cd = false}, RequestType.Json, "");
            return res.code == 1 ? res.data : null;
        }
    }
}