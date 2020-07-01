using com.wandhi.wfbooooot.code.Service;
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
    public class Event_GroupMessage_CHP : IGroupMessage
    {
        void IGroupMessage.GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            if (e.FromGroup == AppData.GroupNumber && e.Message.Text.StartsWith("/骚话"))
            {
                var msg = new ChpService().GetMsg();
                e.FromGroup.SendGroupMessage(msg);
                e.Handler = true;
            }
        }
    }
}
