using System;
using IocManager;

namespace WFBooooot
{
    public class Log : IIocSingletonService
    {
        public void Info(string msg)
        {
            WriteLine(msg, "info");
        }

        public void Debug(string msg)
        {
            WriteLine(msg, "debug");
        }

        private static void WriteLine(string msg, string type)
        {
            Console.WriteLine($"[{type}]:{msg}");
        }
    }
}