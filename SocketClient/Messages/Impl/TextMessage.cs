using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class TextMessage : Messages.Impl.Message
    {
        private string eventName = "message";

        public override string Event => eventName;

        public TextMessage()
        {
            this.MessageType = SocketClientMessageTypes.Message;
        }

        public TextMessage(string textMessage) : this()
        {
            this.MessageText = textMessage;
        }

        public static TextMessage Deserialize(string rawMessage)
        {
            var msg = new TextMessage();
            //  '3:' [message id ('+')] ':' [message endpoint] ':' [data]
            //   3:1::blabla
            msg.RawMessage = rawMessage;

            var args = rawMessage.Split(SPLITCHARS, 4);
            if (args.Length == 4)
            {
                int id;
                if (int.TryParse(args[1], out id))
                    msg.AckId = id;
                msg.Endpoint = args[2];
                msg.MessageText = args[3];
            }
            else
                msg.MessageText = rawMessage;

            return msg;
        }
    }
}