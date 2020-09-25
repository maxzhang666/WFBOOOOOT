using System;
using System.Dynamic;
using SocketClient.Event;
using SocketClient.Message;

namespace SocketClient
{
    public interface ISocketClient
    {
        event EventHandler Opened;
        event EventHandler<MessageEventArgs> Message;
        event EventHandler SocketConnectionClosed;
        event EventHandler<ErrorEventArgs> Error;

        SocketClientHandshake HandShake { get; }
        bool IsConnected { get; }
        WebSocket4Net.WebSocketState ReadyState { get; }

        void Connect();
        IEndPointClient Connect(string endPoint);

        void Close();
        void Dispose();

        void On(string eventName, Action<IMessage> action);
        void On(string eventName, string endPoint, Action<IMessage> action);

        void Emit<T>(string eventName, T payload);
        void Emit<T>(string eventName, T payload, string endPoint = "", Action<object> callBack = null);

        void Send(IMessage msg);
        //void Send(string rawEncodedMessageText);
    }
}