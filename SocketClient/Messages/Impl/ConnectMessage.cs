using Newtonsoft.Json;
using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class ConnectMessage:Messages.Impl.Message
    {
        public object ConnectMsg { get; private set; }

        public override string Event
        {
            get { return "connect"; }
        }

        public ConnectMessage() : base()
        {
            this.MessageType = SocketClientMessageTypes.Connect;
        }
        public ConnectMessage(string endPoint) : this()
        {
            this.Endpoint = endPoint;
        }
        public static ConnectMessage Deserialize(string rawMessage)
        {
            ConnectMessage msg = new ConnectMessage();
            msg.RawMessage = rawMessage;
            msg.ConnectMsg = JsonConvert.DeserializeObject<object>(rawMessage);
            return msg;
        }
        public override string Encoded => string.Format("1::{0}{1}", this.Endpoint, string.Empty, string.Empty);
    }
}