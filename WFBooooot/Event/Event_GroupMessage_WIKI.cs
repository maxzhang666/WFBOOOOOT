using Native.Sdk.Cqp;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFBooooot.Interface;
using WFBooooot.Service;

namespace WFBooooot.Event
{
    /// <summary>
    /// wiki查询群事件
    /// </summary>
    public class Event_GroupMessage_WIKI : IWFGroupMessage
    {
        void IWFGroupMessage.GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            if ((e.FromGroup == AppData.GroupNumber || e.FromGroup == AppData.GroupDebug) && e.Message.Text.ToLower().StartsWith("/wiki"))
            {
                e.CQApi.SendGroupMessage(e.FromGroup, "好嘞，这就去查！");
                //e.Handler = true;

                var service = new WikiService(e.FromGroup, e.FromQQ, e.Message.Text.Replace("/wiki", "").Replace("/Wiki", "").Trim());
                service.send();
            }
        }
    }
}
