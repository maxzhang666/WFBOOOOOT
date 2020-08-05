using System;
using SocketClient.Message;

namespace SocketClient
{
    public interface IEndPointClient
    {
        void On(string eventName, Action<IMessage> action);
        void Emit(string eventName, dynamic payload, Action<dynamic> callBack = null);
        void Send(IMessage msg);
    }
}