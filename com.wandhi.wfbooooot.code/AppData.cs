using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp;
using Unity;

namespace com.wandhi.wfbooooot.code
{
    public static class AppData
    {
        const string AppName = "com.wandhi.wfbooooot";
        /// <summary>
        /// 获取当前 App 使用的 酷Q Api 接口实例
        /// </summary>
        public static CQApi CQApi
        {
            get
            {
                return (CQApi)UnityContainer.Resolve(typeof(CQApi), AppName);
            }
        }

        /// <summary>
        /// 获取当前 App 使用的 酷Q Log 接口实例
        /// </summary>
        public static CQLog CQLog
        {
            get
            {
                return (CQLog)UnityContainer.Resolve(typeof(CQLog), AppName);
            }
        }

        /// <summary>
        /// 获取当前 App 使用的依赖注入容器实例
        /// </summary>
        public static IUnityContainer UnityContainer { get; set; }


        #region 自定义对象
        /// <summary>
        /// 固定群号
        /// </summary>
        public const string GroupNumber = "937826612";
        public const string GroupDebug = "951770042";

        #endregion

    }
}
