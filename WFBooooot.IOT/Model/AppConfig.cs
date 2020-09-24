using System.Collections.Generic;
using System.Diagnostics;
using IocManager;
using WFBooooot.IOT.Service.Warframe;

namespace WFBooooot.IOT.Model
{
    public class AppConfig : IIocSingletonService
    {
        /// <summary>
        /// 服务器
        /// </summary>
        public string Host { get; set; } = "http://127.0.0.1";

        /// <summary>
        /// 端口号
        /// </summary>
        public string Port { get; set; } = "8888";

        public string QQ { set; get; } = "1213068777";

        public List<string> DebugGroup { get; set; }

        public WarframeConfig WarframeConfig { get; set; }

        public AppConfig()
        {
        }

        public AppConfig(List<string> debugGroup)
        {
            DebugGroup = debugGroup;
        }

        public AppConfig(List<string> debugGroup, WarframeConfig warframeConfig)
        {
            DebugGroup = debugGroup;
            WarframeConfig = warframeConfig;
        }
    }
}