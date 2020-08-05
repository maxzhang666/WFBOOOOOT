using System.Linq;
using System.Reflection;
using Unity;

namespace IocManager
{
    public class IocManager : IIocManager
    {
        public IocManager()
        {
            IocContainer = new UnityContainer();
            //register self
            IocContainer.RegisterInstance<IIocManager>(this);
        }

        static IocManager()
        {
            Instance = new IocManager();
        }

        /// <summary>
        /// IOC实例
        /// </summary>
        public static IocManager Instance { get; private set; }

        /// <summary>
        /// 依赖容器
        /// </summary>
        public IUnityContainer IocContainer { get; private set; }
    }
}