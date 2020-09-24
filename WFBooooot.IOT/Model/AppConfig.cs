using System.Collections.Generic;
using System.Diagnostics;
using IocManager;
using WFBooooot.IOT.Service.Warframe;

namespace WFBooooot.IOT.Model
{
    public class AppConfig
    {
        /// <summary>
        /// 服务器
        /// </summary>
        public string Host { get; set; } = "http://127.0.0.1";

        /// <summary>
        /// 端口号
        /// </summary>
        public string Port { get; set; } = "8888";

        /// <summary>
        /// 机器人QQ
        /// </summary>
        public string QQ { set; get; } = "1213068777";

        /// <summary>
        /// 插件生效的群
        /// </summary>
        public List<string> DebugGroup { get; set; }

        /// <summary>
        /// Api配置
        /// </summary>
        public WarframeConfig WarframeConfig { get; set; }
    }
}