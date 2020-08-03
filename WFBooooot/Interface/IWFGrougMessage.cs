using Native.Sdk.Cqp.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFBooooot.Interface
{
    /// <summary>
    /// 群消息事件
    /// </summary>
    public interface IWFGroupMessage
    {
        void GroupMessage(object sender, CQGroupMessageEventArgs e);
    }
}
