using System.Reflection;
using Unity;

namespace IocManager
{
    public interface IWandhiIocManager
    {
        /// <summary>
        /// 注册程序集内所有对象
        /// </summary>
        /// <param name="assembly"></param>
        void RegisterByAssemblies(Assembly assembly);

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        /// 获取容器对象
        /// </summary>
        /// <returns></returns>
        IUnityContainer GetContainer();
    }
}