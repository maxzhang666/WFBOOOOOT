using System;
using IocManager;

namespace OPQ.SDK
{
    public class Log : IIocSingletonService
    {
        public void Info(string msg)
        {
            WriteLine(msg, "info", ConsoleColor.Green);
        }

        public void Debug(string msg)
        {
#if DEBUG
            WriteLine(msg, "debug");
#endif
        }

        public void Error(string msg)
        {
            WriteLine(msg, "error", ConsoleColor.Red);
        }

        private static void WriteLine(string msg, string type, ConsoleColor fontColor = ConsoleColor.White)
        {
            //设置字体颜色
            Console.ForegroundColor = fontColor;
            Console.WriteLine($"[{DateTime.Now}][{type}]:{msg}");
        }
    }
}