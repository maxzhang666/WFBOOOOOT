using System;
using System.Reflection;
using OPQ.SDK;
using OPQ.SDK.Model.Friend;
using WandhiBot.SDK.Http;
using WandhiBot.SDK.Http.Attributes;
using WFBooooot.Test.ProxyTest;

namespace WFBooooot.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var opq=new OpqApi("http://192.168.71.164:8888",1213068777);
            
            opq.SendMessage(new FriendMessage(373884384,"消息测试"));
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}