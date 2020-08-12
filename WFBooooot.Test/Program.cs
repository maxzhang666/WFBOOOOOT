using System;
using WandhiBot.SDK.Http;
using WandhiBot.SDK.Http.Attributes;
using WFBooooot.Test.ProxyTest;

namespace WFBooooot.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client=new TestClient("http://baidu.com");
            
            Console.WriteLine("Hello World!");
        }
    }
}