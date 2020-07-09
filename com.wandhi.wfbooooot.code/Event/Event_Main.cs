using com.wandhi.wfbooooot.code.Extention;
using com.wandhi.wfbooooot.code.Interface;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.Utilities;

namespace com.wandhi.wfbooooot.code.Event
{
    /// <summary>
    /// 事件分发器
    /// 由于框架自带的IOC分发仅触发了一个事件
    /// 所以这里封装一个分发器，使对应的事件分发到注入的每个响应中中
    /// </summary>
    public class Event_Main : IGroupMessage
    {
        /// <summary>
        /// 群消息事件分发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            AppData.UnityContainer.ResolveAll<IWFGroupMessage>().ForEach(a =>
            {
                Task.Factory.StartNew(() =>
                {
                    a.GroupMessage(sender, e);
                });
            });
        }

        /// <summary>
        /// 注册响应事件
        /// </summary>
        public Event_Main()
        {
            Log.Info("注册响应事件");
            //注册群消息事件
            AppData.UnityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_CHP>("群消息-彩虹屁");
            AppData.UnityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_ProWord>("群消息-黑话");
            AppData.UnityContainer.RegisterType<IWFGroupMessage, Event_GroupMessage_WIKI>("群消息-WIki");
        }
    }
}