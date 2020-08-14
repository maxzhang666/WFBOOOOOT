using IocManager;
using OPQ.SDK;
using WFBooooot.IOT.Model;

namespace WFBooooot.IOT
{
    /// <summary>
    /// 应用对象
    /// </summary>
    public static class AppData
    {
        public static IWandhiIocManager WandhiIocManager { get; set; }

        public static OpqApi OpqApi => WandhiIocManager.Resolve<OpqApi>();

        public static AppConfig AppConfig => WandhiIocManager.Resolve<AppConfig>();
    }
}