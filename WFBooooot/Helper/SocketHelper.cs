using System;
using IocManager;
using SocketClient.Event;

namespace WFBooooot.Helper
{
    public class SocketHelper : IIocSingletonService
    {
        private Log _log;

        public SocketHelper(Log log)
        {
            _log = log;
        }

        public void OnSocketError(object sender, ErrorEventArgs e)
        {
            _log.Info($"Socket连接异常:{e.Message}【{e.Exception.Message}】");
        }

        public void OnSocketConnected(object sender, EventArgs e)
        {
            _log.Info("Socket连接成功");
        }

        public void OnSocketConnectionClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Socket连接已关闭");
        }

        public void OnSocketMessage(object sender, MessageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Message.Event))
            {
                _log.Info($"Generic SocketMessage: {e.Message.MessageText}");
            }
            else
            {
                _log.Info($"Generic SocketMessage: {e.Message.Event} : {e.Message.Json}");
            }
        }
    }
}