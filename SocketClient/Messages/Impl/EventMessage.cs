using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class EventMessage : Messages.Impl.Message
    {
        private static object ackLock = new object();
        private static int _akid = 0;
        private string eventName;

        private static int NextAckID
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

        public EventMessage()
        {
            this.MessageType = SocketClientMessageTypes.Event;
        }

        public EventMessage(string eventName, string jsonObject, string endpoint = "", Action<dynamic> callBack = null)
            : this()
        {
            this.Callback = callBack;
            this.Endpoint = endpoint;
            this.eventName = eventName;

            if (callBack != null)
                this.AckId = EventMessage.NextAckID;

            //this.JsonEncodedMessage = new JsonEncodedEventMessage(eventName, jsonObject);
            this.MessageText = jsonObject; // this.Json.ToJsonString();
        }

        public static EventMessage Deserialize(string rawMessage)
        {
            EventMessage evtMsg = new EventMessage();
            evtMsg.RawMessage = rawMessage;
            try
            {
                string askId = rawMessage.Substring(2, rawMessage.IndexOf("[", StringComparison.Ordinal) - 2);
                int id;
                if (int.TryParse(askId, out id))
                    evtMsg.AckId = id;


                var groups = new Regex(@"\[([\s\S]*)\]", RegexOptions.IgnoreCase | RegexOptions.Compiled)
                    .Match(rawMessage).Groups;
                evtMsg.RawMessage = groups[0].Value.Replace("\\", "");
                //jsonMsg.Event = groups[1].Value;
                evtMsg.MessageText = groups[1].Value.Replace("\\", "").Trim('"');
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

            return evtMsg;
        }

        public override string Encoded
        {
            get
            {
                //int msgId = (int)this.MessageType;
                if (this.AckId.HasValue)
                {
                    if (this.Callback == null)
                    {
                        //return string.Format("42{0}[\"{1}\",\"{2}\"]", this.AckId ?? -1, this.eventName, this.MessageText);
                        return
                            $"42{this.AckId ?? -1}[\"{this.eventName}\",\"{this.MessageText.Replace("\"", "\\\"")}\"]";
                    }
                    else
                    {
                        return
                            $"42{this.AckId ?? -1}[\"{this.eventName}\",\"{this.MessageText.Replace("\"", "\\\"")}\"]";
                    }
                }
                else
                {
                    return $"42[\"{this.eventName}\",\"{this.MessageText}\"]";
                }
            }
        }
    }
}