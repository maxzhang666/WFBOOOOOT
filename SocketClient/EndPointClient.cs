using System;
using System.Dynamic;
using System.Linq;
using SocketClient.Message;

namespace SocketClient
{
    public class EndPointClient : IEndPointClient
    {
        public ISocketClient Client { get; private set; }
        public string EndPoint { get; private set; }

        public EndPointClient(ISocketClient client, string endPoint)
        {
            this.validateNameSpace(endPoint);
            this.Client = client;
            this.EndPoint = endPoint;
        }

        private void validateNameSpace(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("nameSpace", "Parameter cannot be null");
            if (name.Contains(':'))
                throw new ArgumentException("Parameter cannot contain ':' characters", "nameSpace");
        }

        public void On(string eventName, Action<IMessage> action)
        {
            this.Client.On(eventName, this.EndPoint, action);
        }

        public void Emit<T>(string eventName, T payload, Action<object> callBack = null)
        {
            this.Client.Emit(eventName, payload, this.EndPoint, callBack);
        }

        public void Send(IMessage msg)
        {
            msg.Endpoint = this.EndPoint;
            this.Client.Send(msg);
        }
    }
}