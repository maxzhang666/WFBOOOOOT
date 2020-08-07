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
            var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            ChangeToken.OnChange(() => fileProvider.Watch(FileName), () =>
            {
                Log.Debug("配置文件变化，重新加载");
                AppConfig = GetConfig();
            });
        }

        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <returns></returns>
        private AppConfig GetConfig()
        {
            AppConfig appConfig;
            if (!File.Exists(_filePath))
            {
                appConfig = new AppConfig();
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(appConfig));
            }
            else
            {
                appConfig = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(_filePath));
            }

            return appConfig;
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        public void SaveConfig()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(AppConfig));
        }
    }
}