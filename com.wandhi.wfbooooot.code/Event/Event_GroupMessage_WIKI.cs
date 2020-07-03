using com.wandhi.wfbooooot.code.Service;
using Native.Sdk.Cqp;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Event
{
    /// <summary>
    /// wiki查询群事件
    /// </summary>
    public class Event_GroupMessage_WIKI : IGroupMessage
    {
        void IGroupMessage.GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            if ((e.FromGroup == AppData.GroupNumber || e.FromGroup == AppData.GroupDebug) && e.Message.Text.StartsWith("/wiki"))
            {
                e.Handler = true;
                
                var service = new WikiService(e.FromGroup);
                service.send();
            }
        }
    }
}
