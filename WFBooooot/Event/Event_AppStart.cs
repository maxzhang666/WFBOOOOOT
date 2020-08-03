using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFBooooot.Event
{
    public class Event_AppStart : IAppEnable
    {
        /// <summary>
        /// 应用启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AppEnable(object sender, CQAppEnableEventArgs e)
        {
            
        }
    }
}
