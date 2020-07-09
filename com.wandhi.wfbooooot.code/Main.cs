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
        /// 请在Natice框架中执行该函数进行事件注册
        /// </summary>
        /// <param name="container">用于注册的 IOC 容器 </param>
        public static void Register(IUnityContainer unityContainer, IUnityContainer unityContainer1)
        {
            #region 注册容器指向            
            AppData.UnityContainer = unityContainer1;
            #endregion

            #region 注册自定义的事件分发器            
            unityContainer.RegisterType<IGroupMessage, Event_Main>("群消息处理");
            #endregion
        }
    }
}
