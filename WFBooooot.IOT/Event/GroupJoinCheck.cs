using System;
using System.Text;
using OPQ.SDK;
using OPQ.SDK.Enum;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WandhiBot.SDK.Model;
using WandhiHelper.Extension;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Helper;
using WFBooooot.IOT.Helper.Interface;

namespace WFBooooot.IOT.Event
{
    public class GroupJoinCheck : IGroupJoinEvent, IGroupMessageEvent
    {
        private readonly ICacheService _cacheService;

        public GroupJoinCheck(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public void GroupJoin(GroupJoinEventArgs e)
        {
            if (e.FromGroup == 937826612 || e.FromGroup == 951770042)
            {
                var sb = new StringBuilder("【新人进群验证】");
                sb.AppendLine("请回答下列验证问题的答案，在验证完成之前您将无法正常发送消息！");
                sb.AppendLine(CommonHelper.CheckCode(out var res));
                sb.Append("注：若您没能在180秒内通过该验证，您将被踢出群！！！");

                _cacheService.Set($"join-check-{e.FromGroup}-{e.FromQQ}", res, TimeSpan.MaxValue);
                AppData.OpqApi.LazyEvent(new GroupJoinCheckKick(e.FromGroup, e.FromQQ, TimeSpan.FromMinutes(3)));

                AppData.OpqApi.SendGroupMessage(e.FromGroup, sb.ToString(), e.FromQQ);
            }
        }

        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (e.FromGroup == 937826612)
            {
                var k = $"join-check-{e.FromGroup}-{e.FromQQ}";
                var res = _cacheService.Get<string>(k);
                if (res.IsNotEmpty())
                {
                    if (e.Msg.Text.Contains(res))
                    {
                        AppData.OpqApi.SendGroupMessage(e.FromGroup, $"验证通过,你可以正常吹逼了！{e.FromQQ.AtUser()}");
                        _cacheService.Remove(k);
                    }
                    else
                    {
                        AppData.OpqApi.RevokeMessage(e.FromGroup, e.Msg);
                    }
                }
            }
        }
    }

    public class GroupJoinCheckKick : ILazyEvent
    {
        private DateTime start;
        private Group fromGroup;
        private QQ qq;
        private TimeSpan interval;
        private ICacheService _cacheService;

        private string key => $"join-check-{fromGroup}-{qq}";

        public GroupJoinCheckKick(Group eFromGroup, QQ eFromQq, TimeSpan fromMinutes)
        {
            fromGroup = eFromGroup;
            qq = eFromQq;
            interval = fromMinutes;
            start = DateTime.Now;
            _cacheService = AppData.WandhiIocManager.Resolve<ICacheService>();
        }

        public void Do()
        {
            var black = _cacheService.Get<string>(key) ?? "";
            if (black.IsNotEmpty() && start.Add(interval) < DateTime.Now)
            {
                AppData.OpqApi.GroupEvent(fromGroup, qq, "", GroupEvent.移出群聊);
                _cacheService.Remove(key);
            }
        }

        public bool CanDo()
        {
            var black = _cacheService.Get<string>(key) ?? "";
            if (black.IsNotEmpty())
            {
                return start.Add(interval) < DateTime.Now;
            }

            return true;
        }
    }
}