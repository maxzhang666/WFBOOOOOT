using System;
using System.Reflection;
using IocManager;
using Unity;

namespace WFBooooot
{
    class Program
    {
        private static ConfigService _configService;
        private static Log _Log;
        private static IWandhiIocManager _WandhiIocManager;

        static void Main(string[] args)
        {
            //初始化依赖
            Init();


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        static void Init()
        {
            //注册容器
            _WandhiIocManager = new WandhiWandhiIocManager();
            _WandhiIocManager.RegisterByAssemblies(Assembly.GetExecutingAssembly());

            //初始化组件
            _configService = _WandhiIocManager.Resolve<ConfigService>();
            _Log = _WandhiIocManager.Resolve<Log>();
        }
    }
}