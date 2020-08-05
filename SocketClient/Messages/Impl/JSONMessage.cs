using System;
using Newtonsoft.Json;
using SocketClient.Enum;

namespace SocketClient.Message.Impl
{
    public class JSONMessage : Messages.Impl.Message
    {
        public void SetMessage(object value)
        {
            this.MessageText = JsonConvert.SerializeObject(value, Formatting.None);
        }

        public virtual T Message<T>()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(this.MessageText);
            }
            catch (Exception ex)
            {
                // add error logging here
                throw;
            }
        }

        public JSONMessage()
        {
            this.MessageType = SocketClientMessageTypes.JSONMessage;
        }

        public JSONMessage(object jsonObject, int? ackId = null, string endpoint = null) : this()
        {
            this.AckId = ackId;
            this.Endpoint = endpoint;
            this.MessageText = JsonConvert.SerializeObject(jsonObject, Formatting.None);
        }

        public static JSONMessage Deserialize(string rawMessage)
        {
            var jsonMsg = new JSONMessage();
            var groups = ReMessageType.Match(rawMessage).Groups;
            jsonMsg.RawMessage = groups[0].Value;
            jsonMsg.Event = groups[1].Value;
            jsonMsg.MessageText = groups[2].Value;
            return jsonMsg;
        }
    }
}