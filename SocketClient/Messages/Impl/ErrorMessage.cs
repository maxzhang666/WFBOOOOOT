using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class ErrorMessage : Messages.Impl.Message
    {
        public string Reason { get; set; }
        public string Advice { get; set; }

        public override string Event
        {
            get { return "error"; }
        }

        public ErrorMessage()
        {
            this.MessageType = SocketClientMessageTypes.Error;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawMessage">'7::' [endpoint] ':' [reason] '+' [advice]</param>
        /// <returns>ErrorMessage</returns>
        public static ErrorMessage Deserialize(string rawMessage)
        {
            var errMsg = new ErrorMessage();
            var args = rawMessage.Split(':');
            if (args.Length != 4)
            {
                return errMsg;
            }

            errMsg.Endpoint = args[2];
            errMsg.MessageText = args[3];
            var complex = args[3].Split(new char[] {'+'});
            if (complex.Length <= 1)
            {
                return errMsg;
            }

            errMsg.Advice = complex[1];
            errMsg.Reason = complex[0];

            return errMsg;
        }
    }
}