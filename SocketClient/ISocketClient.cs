using System;
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

        void Emit(string eventName, dynamic payload);
        void Emit(string eventName, dynamic payload, string endPoint = "", Action<dynamic> callBack = null);

        void Send(IMessage msg);
        //void Send(string rawEncodedMessageText);
    }
}