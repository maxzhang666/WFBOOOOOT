using System.Collections.Generic;
using System.IO;
using IocManager;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using WandhiHelper.Extension;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Model;
using WFBooooot.IOT.Service.Warframe;

namespace WFBooooot.IOT
{
    /// <summary>
    /// 配置文件类
    /// </summary>
    public class ConfigService : IIocSingletonService
    {
        private const string FileName = "app.config.json";
        private readonly string _filePath = $"{Directory.GetCurrentDirectory()}/{FileName}";
        private FileSystemWatcher _watcher = new FileSystemWatcher(Directory.GetCurrentDirectory(), FileName);

        /// <summary>
        /// 日志工具
        /// </summary>
        public readonly Log Log;

        public AppConfig AppConfig { private set; get; }

        public ConfigService(Log log)
        {
            Log = log;
            AppConfig = InitConfig();
            WatchFileChange();
        }


        /// <summary>
        /// 配置文件变化监控
        /// </summary>
        private void WatchFileChange()
        {
            _watcher.EnableRaisingEvents = true;
            _watcher.Changed += (sender, e) =>
            {
                _watcher.EnableRaisingEvents = false;
                Log.Debug("配置文件变化，重新加载");
                AppConfig = InitConfig();
                _watcher.EnableRaisingEvents = true;
            };
        }

        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <returns></returns>
        private AppConfig InitConfig()
        {
            if (!File.Exists(_filePath))
            {
                AppConfig = InitDefaultConfig();
                SaveConfig();
            }
            else
            {
                var json = File.ReadAllText(_filePath);
                AppConfig = (json.IsNotEmpty() && json != "null") ? JsonConvert.DeserializeObject<AppConfig>(json) : InitDefaultConfig();
            }

            Log.Info($"配置文件读取结束:{JsonConvert.SerializeObject(AppConfig)}");
            return AppConfig;
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        public void SaveConfig()
        {
            Log.Info("保存配置信息");
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(AppConfig, Formatting.Indented));
        }

        private AppConfig InitDefaultConfig()
        {
            AppConfig ??= new AppConfig();
            AppConfig.DebugGroup ??= new List<string> {"951770042"};
            AppConfig.WarframeConfig ??= new WarframeConfig
            {
                ClientId = "7d5f1b7c821c46a49d820ee4ba24ed7b",
                ClientSecret = "09075310b225426f848a4bdd4adbef69"
            };
            AppConfig.KeywordConfig ??= new KeywordConfig
            {
                Groups = new List<string> {"340569308", "655341576", "722457505", "951770042"},
                KeyWords = new Dictionary<string, string>
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
                }
            };
            AppConfig.RedisConfig ??= new RedisConfig();
            return AppConfig;
        }
    }
}