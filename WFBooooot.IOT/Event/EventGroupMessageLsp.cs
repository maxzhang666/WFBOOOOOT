using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GHttpHelper;
using OPQ.SDK;
using OPQ.SDK.Model.Group;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WandhiBot.SDK.Model;
using WFBooooot.IOT.Helper;
using WFBooooot.IOT.Helper.Interface;
using WFBooooot.IOT.Model.Lsp;

namespace WFBooooot.IOT.Event
{
    /// <summary>
    /// LSP 来张色图
    /// </summary>
    public class EventGroupMessageLsp : IGroupMessageEvent
    {
        private ICacheService _cacheHelper;

        public EventGroupMessageLsp(ICacheService cacheHelper)
        {
            _cacheHelper = cacheHelper;
        }

        public void GroupMessage(GroupMessageEventArgs e)
        {
            var reg = new Regex(@"消息编号:\[([0-9]*)\]");
            if (reg.IsMatch(e.Msg.Text))
            {
                var match = reg.Match(e.Msg.Text);
                var msgNo = match?.Groups[1].Value;
                if (!string.IsNullOrEmpty(msgNo))
                {
                    _cacheHelper.Set(msgNo, e, TimeSpan.FromMinutes(5));
                }
            }
            else if (e.Msg.Text.Contains(@"/撤回"))
            {
                _RevokeLsp(e);
            }
            else if (e.Msg.Text.Contains("涩批指数"))
            {
                AppData.OpqApi.LazyEvent(new EventLazyRevoke(e.FromGroup, e.Msg, DateTime.Now.AddSeconds(60)));
            }
            else
            {
                _GroupMessage(e);
            }
        }

        private void _RevokeLsp(GroupMessageEventArgs e)
        {
            var msg = "";
            if (e.FromQQ == 373884384 || e.FromQQ == 1257262199)
            {
                var reg = new Regex(@"撤回 ([0-9]*)");
                if (!reg.IsMatch(e.Msg.Text))
                {
                    return;
                }

                var match = reg.Match(e.Msg.Text);
                var msgNo = match?.Groups[1].Value;
                var qqMessage = _cacheHelper.Get<GroupMessageEventArgs>(msgNo);

                if (qqMessage != null)
                {
                    AppData.OpqApi.RevokeMessage(qqMessage.FromGroup, qqMessage.Msg);
                    msg = "好耶！撤回成功！！\r\n这次大家都没的冲了~";
                }
                else
                {
                    msg = "啊哦,没找到这条信息耶~";
                }
            }
            else
            {
                msg = "小伙子你木得权限啊,冲冲冲！！";
            }

            AppData.OpqApi.SendGroupMessage(e.FromGroup, msg);
        }

        /// <summary>
        /// 涩图流程
        /// </summary>
        /// <param name="e"></param>
        private void _GroupMessage(GroupMessageEventArgs e)
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
            if (DateTime.Now - lastTime > TimeSpan.FromMinutes(2) || e.FromQQ == 373884384)
            {
                _cacheHelper.Set("lsp", DateTime.Now, TimeSpan.FromMinutes(5));
                // AppData.OpqApi.SendMessage(new GroupMessage(e.FromGroup, $"[ATUSER({e.FromQQ})] 有内鬼，终止交易！"));
                // return;
                AppData.OpqApi.SendGroupMessage(e.FromGroup, "好嘞，马上就给你");
                var flag = e.FromQQ == 373884384 && (key.Contains("18") || key.Contains("牛批"));
                var url = GetPicUrl(out var info, flag);
                var msg = $"\r\n收好了您，哎~慢走(手机查看)\r\nPid:{info.pid}\r\n画师:{info.author}";
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

                msg += $"\r\n冲冲冲!一会就没了";
                msg += $"\r\n消息编号:[{GetTimeStamp()}]";

                msg += $"[ATUSER({e.FromQQ})]";
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

                msg += $"[ATUSER({e.FromQQ})]";
                AppData.OpqApi.SendGroupMessage(e.FromGroup, msg, e.FromQQ);
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

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public string GetTimeStamp()
        {
            var ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}