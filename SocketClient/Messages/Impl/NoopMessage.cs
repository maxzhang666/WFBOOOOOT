using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class NoopMessage : Messages.Impl.Message
    {
        public NoopMessage()
        {
            this.MessageType = SocketClientMessageTypes.Noop;
        }

        public static NoopMessage Deserialize(string rawMessage)
        {
            return new NoopMessage();
        }
    }
}