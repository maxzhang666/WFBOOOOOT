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
        public List<string> Groups { set; get; } = new List<string> {"340569308", "655341576", "722457505", "951770042"};

        /// <summary>
        /// 关键字词库
        /// 键名-关键字
        /// 键值-回复消息
        /// </summary>
        public Dictionary<string, string> KeyWords { set; get; } = new Dictionary<string, string>
        {
            {
                "百度", @"百度网盘VIP账号，2天只需1.5元(共享账号概率限速，介意勿扰)
迅雷Vip 每天只需1.5元，1周只需4元
另新增各种其他业务
详情点击：http://t.cn/AiOEzcrZ"
            },
            {
                "迅雷", @"百度网盘VIP账号，2天只需1.5元(共享账号概率限速，介意勿扰)
迅雷Vip 每天只需1.5元，1周只需4元
另新增各种其他业务
详情点击：http://t.cn/AiOEzcrZ"
            },
            {
                "翻墙", @"禁止讨论任何形式的翻Q软件

违者直接飞机票

PS：私聊不管"
            }
        };
    }
}