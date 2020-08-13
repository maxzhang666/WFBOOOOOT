using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IocManager;
using Newtonsoft.Json;
using OPQ.SDK;
using OPQ.SDK.Enum;
using SocketClient;
using SocketClient.Message.Impl;
using Unity;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WandhiBot.SDK.Model;
using WFBooooot.IOT.Helper;
using WFBooooot.IOT.Model;

namespace WFBooooot.IOT
{
    class Program
    {
        private static ConfigService _ConfigService;
        private static Log _Log;
        private static IWandhiIocManager _WandhiIocManager;
        private static SocketHelper _SocketHelper;
        private static OpqSocket _OpqSocket;

        static void Main(string[] args)
        {
            //初始化依赖
            Init();
            //初始化Socket连接
            SocketInti();


            Hold();
        }

        static void SocketInti()
        {
            var uri = _ConfigService.AppConfig.Host.IndexOf("http", StringComparison.Ordinal) > -1
                ? $"{_ConfigService.AppConfig.Host}:{_ConfigService.AppConfig.Port}/"
                : $"http://{_ConfigService.AppConfig.Host}:{_ConfigService.AppConfig.Port}/";
            //传入容器，自行管理对象

            _OpqSocket = new OpqSocket(_ConfigService.AppConfig.Host, _ConfigService.AppConfig.Port, _ConfigService.AppConfig.QQ, AppDomain.CurrentDomain.GetAssemblies(), _WandhiIocManager);

            _OpqSocket.SocketClient.Opened += _SocketHelper.OnSocketConnected;
            _OpqSocket.SocketClient.Message += _SocketHelper.OnSocketMessage;
            _OpqSocket.SocketClient.SocketConnectionClosed += _SocketHelper.OnSocketConnectionClosed;
            _OpqSocket.SocketClient.Error += _SocketHelper.OnSocketError;

            _OpqSocket.Connect();

            //二维码检测事件
            _OpqSocket.On(EventType.OnCheckLoginQrcode,
                (fn) => { Console.WriteLine("OnCheckLoginQrcode\n" + ((JSONMessage) fn).MessageText); });
            //收到好友消息的回调事件
            _OpqSocket.On(EventType.OnFriendMsgs,
                (fn) => { Console.WriteLine("OnFriendMsgs\n" + ((JSONMessage) fn).MessageText); });
            //统一事件管理如好友进群事件 好友请求事件 退群等事件集合
            _OpqSocket.On(EventType.OnEvents, (fn) => { Console.WriteLine("OnEnevts\n" + ((JSONMessage) fn).MessageText); });
        }

        /// <summary>
        /// 控制台保持
        /// </summary>
        static void Hold()
        {
            while (true)
            {
                var key = Console.ReadLine();
                if (key.ToLower() == "exit")
                {
                    break;
                }
            }
        }

        static void Init()
        {
            //注册容器
            _WandhiIocManager = new WandhiWandhiIocManager();
            _WandhiIocManager.RegisterByAssemblies(Assembly.GetExecutingAssembly());

            //初始化组件
            _ConfigService = _WandhiIocManager.Resolve<ConfigService>();
            _SocketHelper = _WandhiIocManager.Resolve<SocketHelper>();
            _Log = _WandhiIocManager.Resolve<Log>();
        }
    }
}