using System;
using System.Dynamic;
using SocketClient.Message;

namespace SocketClient
{
    public interface IEndPointClient
    {
        void On(string eventName, Action<IMessage> action);
        void Emit<T>(string eventName, T payload, Action<object> callBack = null);
        void Send(IMessage msg);
    }
}