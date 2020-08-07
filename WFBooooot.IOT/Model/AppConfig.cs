using System.Collections.Generic;
using IocManager;

namespace WFBooooot.IOT.Model
{
    public class AppConfig : IIocService
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
    }
}