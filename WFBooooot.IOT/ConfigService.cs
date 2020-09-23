using System.Collections.Generic;
using System.IO;
using IocManager;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using WFBooooot.IOT.Model;

namespace WFBooooot.IOT
{
    /// <summary>
    /// 配置文件类
    /// </summary>
    public class ConfigService : IIocSingletonService
    {
        private const string FileName = "app.config.json";
        private readonly string _filePath = $"{Directory.GetCurrentDirectory()}/{FileName}";
        private readonly Log Log;
        public AppConfig AppConfig { private set; get; }

        public ConfigService(Log log)
        {
            Log = log;
            AppConfig = GetConfig();
            WatchFileChange();
        }


        /// <summary>
        /// 配置文件变化监控
        /// </summary>
        private void WatchFileChange()
        {
            var watcher = new FileSystemWatcher(Directory.GetCurrentDirectory(), FileName);

            watcher.Changed += (sender, e) =>
            {
                Log.Debug("配置文件变化，重新加载");
                AppConfig = GetConfig();
            };
        }

        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <returns></returns>
        private AppConfig GetConfig()
        {
            AppConfig appConfig;
            Log.Info($"准备读取配置文件……{_filePath}");
            if (!File.Exists(_filePath))
            {
                Log.Info("配置文件不存在，准备写入默认配置文件……");
                appConfig = new AppConfig(new List<string> {"951770042"});
                SaveConfig();
            }
            else
            {
                appConfig = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(_filePath));
            }

            Log.Info($"配置文件读取结束:{JsonConvert.SerializeObject(appConfig)}");

            return appConfig;
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        public void SaveConfig()
        {
            Log.Info("保存配置信息");
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(AppConfig));
        }
    }
}