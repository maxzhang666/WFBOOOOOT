using System.Collections.Generic;
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

        public List<string> DebugGroup { get; set; } = new List<string> {"951770042"};

        public WarframeConfig WarframeConfig { get; set; } = new WarframeConfig {ClientId = "1d6c7c5cae574d02ac3ad1a9e8ef01b0", ClientSecret = "68dc306bbb9348e694a35828c8975a08"};
    }
}