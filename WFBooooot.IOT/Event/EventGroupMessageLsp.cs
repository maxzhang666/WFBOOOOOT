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

            var lastTime = _cacheHelper.Get("lsp", DateTime.Now - TimeSpan.FromMinutes(2));
            if (DateTime.Now - lastTime > TimeSpan.FromMinutes(2))
            {
                _cacheHelper.Set("lsp", DateTime.Now);
                AppData.OpqApi.SendGroupMessage(e.FromGroup, "好嘞，马上就给你");
                var flag = e.FromQQ == 373884384 && (key.Contains("18") || key.Contains("牛批"));
                var url = GetPicUrl(out var info, flag);
                var msg = $"\r\n收好了您，哎~慢走\r\nPid:{info.pid}\r\n画师:{info.author}";
                var data = LspCount(e.FromQQ, e.FromQQ.NickName);
                if (data != null)
                {
                    var p = Math.Round(data.info.sp_count / double.Parse(data.count) * 100, 2, MidpointRounding.AwayFromZero);
                    msg += $"\r\n你的涩批指数：【{p}%】";
                    if (p > 10)
                    {
                        msg += "\r\n原来你就是传说的LSP！！";
                    }
                }

                AppData.OpqApi.SendMessage(new GroupImgMessage(e.FromGroup, msg, url, flag));
            }
            else
            {
                var data = LspCdCount(e.FromQQ, e.FromQQ.NickName);
                var msg = $"这么快就冲完了？缓缓吧";
                if (data != null)
                {
                    var p = Math.Round(data.info.sp_cd_count / double.Parse(data.cd_count) * 100, 2, MidpointRounding.AwayFromZero);
                    msg += $"\r\n饥渴指数：【{p}%】";
                    if (p > 10)
                    {
                        msg += "\r\n莫非！！！你就是氏族最快的男人！！！！~";
                    }
                }

                AppData.OpqApi.SendGroupMessage(e.FromGroup, msg);
            }
        }

        /// <summary>
        /// 获取图片地址
        /// </summary>
        /// <param name="isR18">是否获取R18</param>
        /// <returns></returns>
        private string GetPicUrl(out DataItem Info, bool isR18 = false)
        {
            var res = Http.Get<Lsp>($"https://api.lolicon.app/setu/?apikey=071046145f51a2a084d2c5&r18={(isR18 ? "1" : "0")}");
            Info = res.data.FirstOrDefault();
            return res.data.FirstOrDefault()?.url;
        }

        /// <summary>
        /// lsp统计
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="nickname"></param>
        private LspData LspCdCount(string qq, string nickname)
        {
            var res = Http.Post<LspAnalyze>("https://api.wandhi.com/api/tools/lsp", new {qq = qq, nickname, cd = true}, RequestType.Form, "");
            return res.code == 1 ? res.data : null;
        }

        /// <summary>
        /// lsp普通统计
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="nickname"></param>
        /// <returns></returns>
        private LspData LspCount(string qq, string nickname)
        {
            var res = Http.Post<LspAnalyze>("https://api.wandhi.com/api/tools/lsp", new {qq = qq, nickname}, RequestType.Form, "");
            return res.code == 1 ? res.data : null;
        }
    }
}