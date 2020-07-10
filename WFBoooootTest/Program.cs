using com.wandhi.wfbooooot.code.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFBoooootTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var wiki = new WikiService();

            Info(wiki.GetMsg("行动代号：瘟疫之星"));


            Console.ReadLine();
        }

        static void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
        }
    }
}
