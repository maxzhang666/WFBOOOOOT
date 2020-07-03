using com.wandhi.wfbooooot.code.Event;
using Native.Sdk.Cqp;
using Native.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace com.wandhi.wfbooooot.code
{
    public class Main
    {
        /// <summary>
        /// 在应用被加载时将调用此方法进行事件注册, 请在此方法里向 <see cref="IUnityContainer"/> 容器中注册需要使用的事件
        /// </summary>
        /// <param name="container">用于注册的 IOC 容器 </param>
        public static void Register(IUnityContainer unityContainer, IUnityContainer unityContainer1)
        {


            #region 注册事件
            //彩虹屁、骚话
            unityContainer.RegisterType<IGroupMessage, Event_GroupMessage_CHP>("群消息处理");
            unityContainer.RegisterType<IGroupMessage, Event_GroupMessage_WIKI>("群消息处理");
            #endregion

            #region 注册app指向
            //AppData.CQLog = CQLog;
            //AppData.CQLog.Info("事件注册完成");
            //AppData.CQApi = CQApi;
            AppData.UnityContainer = unityContainer1;
            #endregion
        }
    }
}
