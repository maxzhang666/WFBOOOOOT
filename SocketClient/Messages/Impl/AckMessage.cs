using System;
using System.Text.RegularExpressions;
using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class AckMessage:Messages.Impl.Message
    {
        private static Regex reAckId = new Regex(@"^(\d{1,})");
        private static Regex reAckPayload = new Regex(@"(?:[\d\+]*)(?<data>.*)$");
        private static Regex reAckComplex = new Regex(@"^\[(?<payload>.*)\]$");

        private static object ackLock = new object();
        private static int _akid = 0;
        public static int NextAckID
        {
            get
            {
                lock (ackLock)
                {
                    _akid++;
                    if (_akid < 0)
                        _akid = 0;
                    return _akid;
                }
            }
        }

        public Action<dynamic> Callback;

        public AckMessage()
            : base()
        {
            this.MessageType = SocketClientMessageTypes.ACK;
        }
		
        public static AckMessage Deserialize(string rawMessage)
        {
            AckMessage msg = new AckMessage();
	
            msg.RawMessage = rawMessage;

            string askId = rawMessage.Substring(2, rawMessage.IndexOf("[") - 2);
            int id;
            if (int.TryParse(askId, out id))
                msg.AckId = id;
            var groups = new Regex(@"\[([\s\S]*)\]", RegexOptions.IgnoreCase | RegexOptions.Compiled).Match(rawMessage).Groups;
            msg.RawMessage = groups[0].Value.Replace("\\", "");
            //jsonMsg.Event = groups[1].Value;
            msg.MessageText = groups[1].Value.Replace("\\", "").Trim('"');
            return msg;
        }
        public override string Encoded
        {
            get
            {
                int msgId = (int)this.MessageType;
                if (this.AckId.HasValue)
                {
                    if (this.Callback == null)
                    {
                        return $"{msgId}:{this.AckId ?? -1}:{this.Endpoint}:{this.MessageText}";
                    }
                    else
                    {
                        return $"{msgId}:{this.AckId ?? -1}+:{this.Endpoint}:{this.MessageText}";
                    }
                }
                else
                {
                    return $"{msgId}::{this.Endpoint}:{this.MessageText}";
                }
            }
        }
    }
}