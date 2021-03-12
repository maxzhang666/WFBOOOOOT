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
        /// redis配置
        /// </summary>
        public RedisConfig RedisConfig { set; get; }

        /// <summary>
        /// Api配置
        /// </summary>
        public WarframeConfig WarframeConfig { get; set; }

        /// <summary>
        /// 关键字词库
        /// </summary>
        public KeywordConfig KeywordConfig { set; get; }
    }

    /// <summary>
    /// 关键字词库配置
    /// </summary>
    public class KeywordConfig
    {
        /// <summary>
        /// 生效的群
        /// </summary>
        public List<string> Groups { set; get; }

        /// <summary>
        /// 关键字词库
        /// 键名-关键字
        /// 键值-回复消息
        /// </summary>
        public Dictionary<string, string> KeyWords { set; get; }
    }
}