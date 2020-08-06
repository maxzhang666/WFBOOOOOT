using System.Linq;
using System.Reflection;
using Unity;

namespace IocManager
{
    public class WandhiWandhiIocManager : IWandhiIocManager
    {
        public WandhiWandhiIocManager()
        {
            IocContainer = new UnityContainer();
            //register self
            IocContainer.RegisterInstance<IWandhiIocManager>(this);
        }

        static WandhiWandhiIocManager()
        {
            Instance = new WandhiWandhiIocManager();
        }

        /// <summary>
        /// 根据程序集注册所有的对象
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterByAssemblies(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(e => e.GetInterfaces().Contains(typeof(IIocService)));

            //注册对象
            foreach (var item in types)
            {
                IocContainer.RegisterType(item);
            }

            var singletonTypes =
                assembly.GetTypes().Where(e => e.GetInterfaces().Contains(typeof(IIocSingletonService)));

            //注册单例对象
            foreach (var item in singletonTypes)
            {
                IocContainer.RegisterSingleton(item);
            }
        }

        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }

        public IUnityContainer GetContainer()
        {
            return IocContainer;
        }

        /// <summary>
        /// IOC实例
        /// </summary>
        public static WandhiWandhiIocManager Instance { get; private set; }

        /// <summary>
        /// 依赖容器
        /// </summary>
        public IUnityContainer IocContainer { get; private set; }
    }
}