using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class DisconnectMessage : Messages.Impl.Message
    {
        public override string Event => "disconnect";

        public DisconnectMessage() : base()
        {
            this.MessageType = SocketClientMessageTypes.Disconnect;
        }

        public DisconnectMessage(string endPoint)
            : this()
        {
            this.Endpoint = endPoint;
        }

        public static DisconnectMessage Deserialize(string rawMessage)
        {
            DisconnectMessage msg = new DisconnectMessage();
            //  0::
            //  0::/test
            msg.RawMessage = rawMessage;

            var args = rawMessage.Split(SPLITCHARS, 3);
            if (args.Length != 3)
            {
                return msg;
            }

            if (!string.IsNullOrWhiteSpace(args[2]))
                msg.Endpoint = args[2];
            return msg;
        }

        public override string Encoded => $"0::{this.Endpoint}";
    }
}