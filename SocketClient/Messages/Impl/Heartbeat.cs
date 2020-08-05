using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class Heartbeat:Messages.Impl.Message
    {
        public static string HEARTBEAT = "2";

        public Heartbeat()
        {
            this.MessageType = SocketClientMessageTypes.Heartbeat;
        }

        public override string Encoded => HEARTBEAT;
    }
}