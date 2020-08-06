using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;

namespace SocketClient.Message.Impl
{
    public class JsonEncodedEventMessage
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "args")] public dynamic[] Args { get; set; }

        public JsonEncodedEventMessage()
        {
        }

        public JsonEncodedEventMessage(string name, object payload) : this(name, new[] {payload})
        {
        }

        public JsonEncodedEventMessage(string name, object[] payloads)
        {
            this.Name = name;
            this.Args = payloads;
        }

        public T GetFirstArgAs<T>()
        {
            try
            {
                var firstArg = this.Args.FirstOrDefault();
                if (firstArg != null)
                    return JsonConvert.DeserializeObject<T>(firstArg.ToString());
            }
            catch (Exception ex)
            {
                // add error logging here
                throw;
            }

            return default(T);
        }

        public IEnumerable<T> GetArgsAs<T>()
        {
            var items = this.Args.Select(i => JsonConvert.DeserializeObject<T>(i.ToString(Formatting.None))).Cast<T>()
                .ToList();
            return items.AsEnumerable();
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public static JsonEncodedEventMessage Deserialize(string jsonString)
        {
            JsonEncodedEventMessage msg = null;
            try
            {
                msg = JsonConvert.DeserializeObject<JsonEncodedEventMessage>(jsonString);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

            return msg;
        }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static implicit operator string(JsonEncodedEventMessage jsonEncodedEventMessage)
        {
            return jsonEncodedEventMessage.ToString();
        }
    }
}