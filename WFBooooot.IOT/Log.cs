using System;
using IocManager;

namespace WFBooooot.IOT
{
    public class Log : IIocSingletonService
    {
        public void Info(string msg)
        {
            WriteLine(msg, "info");
        }

        public void Debug(string msg)
        {
#if DEBUG
            WriteLine(msg, "debug");
#endif
        }

        private static void WriteLine(string msg, string type)
        {
            Console.WriteLine($"[{DateTime.Now}][{type}]:{msg}");
        }
    }
}