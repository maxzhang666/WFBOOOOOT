using System;
using System.Text;
using OPQ.SDK;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WandhiHelper.Extension;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Helper;
using WFBooooot.IOT.Helper.Interface;

namespace WFBooooot.IOT.Event
{
    public class GroupCommingCheck : IGroupJoinEvent,IGroupMessageEvent
    {
        private ICacheService _cacheService;

        public GroupCommingCheck(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public void GroupJoin(GroupJoinEventArgs e)
        {
            if (e.FromGroup == 937826612)
            {
                var sb = new StringBuilder("【新人进群验证】");
                sb.AppendLine("请回答下列验证问题的答案，在验证完成之前您将无法正常发送消息！");
                sb.AppendLine(CommonHelper.CheckCode(out var res));

                _cacheService.Set($"join-check-{e.FromGroup}-{e.FromQQ}", res, TimeSpan.MaxValue);

                AppData.OpqApi.SendGroupMessage(e.FromGroup, "验证:", e.FromQQ);
            }
        }

        public void GroupMessage(GroupMessageEventArgs e)
        {
            if (e.FromGroup == 937826612)
            {
                var res = _cacheService.Get<string>($"join-check-{e.FromGroup}-{e.FromQQ}");
                if (res.IsNotEmpty())
                {
                    if (e.Msg.Text.Contains(res))
                    {
                        AppData.OpqApi.SendGroupMessage(e.FromGroup, $"验证通过,你可以正常吹逼了！{e.FromQQ.AtUser()}");
                    }
                    else
                    {
                        AppData.OpqApi.RevokeMessage(e.FromGroup, e.Msg);
                    }
                }
            }
        }
    }
}