using com.wandhi.wfbooooot.code.Interface;
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
    /// 黑话群事件
    /// </summary>
    public class Event_GroupMessage_ProWord : IWFGroupMessage
    {
        void IWFGroupMessage.GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            if ((e.FromGroup == AppData.GroupNumber || e.FromGroup == AppData.GroupDebug) && e.Message.Text.ToLower().StartsWith("/黑话"))
            {
                e.CQApi.SendGroupMessage(e.FromGroup, "为萌新送上术语黑话：https://gitee.com/ixysy/WFBOOOOOT/blob/master/%E8%90%8C%E6%96%B0%E6%9C%AF%E8%AF%AD%E5%85%A5%E9%97%A8.md");     
            }
        }
    }
}
