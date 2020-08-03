using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFBooooot.Extention
{
    /// <summary>
    /// 本地日志记录
    /// </summary>
    public static class Log
    {

        public static void Info(string Msg)
        {
            WriteLog(Msg, "Info");
        }
        public static void Debug<T>(T Msg)
        {
            Debug(JsonConvert.SerializeObject(Msg));
        }
        public static void Debug(string Msg)
        {
            WriteLog(Msg, "Debug");
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="Level"></param>
        static void WriteLog(string Msg, string Level)
        {
            string logPath = AppDomain.CurrentDomain.BaseDirectory + $"WFBOOOOOT";
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string logFile = $"\\{Level}-{DateTime.Now.ToString("yyyy-MM-dd")}.log";
            using (StreamWriter sw = File.AppendText(logPath + logFile))
            {
                sw.WriteLine("**************************************************");
                sw.WriteLine($"Time：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                sw.WriteLine($"{Msg}");
            }
        }
    }
}
