using System;
using System.Reflection;
using IocManager;
using Unity;

namespace WFBooooot
{
    class Program
    {
        private static ConfigService _ConfigService;
        private static Log _Log;
        private static IWandhiIocManager _WandhiIocManager;

        static void Main(string[] args)
        {
            //初始化依赖
            Init();

            Hold();
        }

        static void Hold()
        {
            while (true)
            {
                var key = Console.ReadLine();
                if (key.ToLower() == "exit")
                {
                    break;
                }
            }
        }

        static void Init()
        {
            //注册容器
            _WandhiIocManager = new WandhiWandhiIocManager();
            _WandhiIocManager.RegisterByAssemblies(Assembly.GetExecutingAssembly());

            //初始化组件
            _ConfigService = _WandhiIocManager.Resolve<ConfigService>();
            _Log = _WandhiIocManager.Resolve<Log>();
        }
    }
}