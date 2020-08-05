using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using SocketClient.Enum;
using SocketClient.Message;
using SocketClient.Message.Impl;

namespace SocketClient.Messages.Impl
{
    public class Message : IMessage
    {
        private static Regex re = new Regex(@"\d:\d?:\w?:");
        public static char[] SPLITCHARS = new char[] {':'};

        public string RawMessage { get; protected set; }

        /// <summary>
        /// The message type represents a single digit integer [0-8].
        /// </summary>
        public SocketClientMessageTypes MessageType { get; protected set; }

        /// <summary>
        /// The message id is an incremental integer, required for ACKs (can be ommitted). 
        /// If the message id is followed by a +, the ACK is not handled by socket.io, but by the user instead.
        /// </summary>
        public int? AckId { get; set; }

        /// <summary>
        /// Socket.IO has built-in support for multiple channels of communication (which we call "multiple sockets"). 
        /// Each socket is identified by an endpoint (can be omitted).
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// String value of the message
        /// </summary>
        public string MessageText { get; set; }

        private JsonEncodedEventMessage _json;

        [Obsolete(".JsonEncodedMessage has been deprecated. Please use .Json instead.")]
        public JsonEncodedEventMessage JsonEncodedMessage
        {
            get { return this.Json; }
            set { this._json = value; }
        }

        public JsonEncodedEventMessage Json
        {
            get
            {
                if (_json == null)
                {
                    if (!string.IsNullOrEmpty(this.MessageText) &&
                        this.MessageText.Contains("name") &&
                        this.MessageText.Contains("args"))
                    {
                        this._json = JsonEncodedEventMessage.Deserialize(this.MessageText);
                    }
                    else
                        this._json = new JsonEncodedEventMessage();
                }

                return _json;
            }
            set => this._json = value;
        }

        /// <summary>
        /// String value of the Event
        /// </summary>
        public virtual string Event { get; set; }

        /// <summary>
        /// <para>Messages have to be encoded before they're sent. The structure of a message is as follows:</para>
        /// <para>[message type] ':' [message id ('+')] ':' [message endpoint] (':' [message data])</para>
        /// <para>All message payloads are sent as strings</para>
        /// </summary>
        public virtual string Encoded
        {
            get
            {
                var msgId = (int) this.MessageType;
                if (this.AckId.HasValue)
                    return $"{msgId}:{this.AckId ?? -1}:{this.Endpoint}:{this.MessageText}";
                else
                    return $"{msgId}::{this.Endpoint}:{this.MessageText}";
            }
        }


        public Message()
        {
            this.MessageType = SocketClientMessageTypes.Message;
        }

        public Message(string rawMessage)
            : this()
        {
            this.RawMessage = rawMessage;

            string[] args = rawMessage.Split(SPLITCHARS, 4);
            if (args.Length == 4)
            {
                int id;
                if (int.TryParse(args[1], out id))
                    this.AckId = id;
                this.Endpoint = args[2];
                this.MessageText = args[3];
            }
        }

        public static Regex ReMessageType =
            new Regex(@"\[""(\w+)"",([\s\S]*)\]", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool Check(string text) => text.StartsWith("0{\"sid\":\"");

        public static IMessage Factory(string rawMessage)
        {
            if (Check(rawMessage))
            {
                string message = rawMessage.TrimStart('0');

                return ConnectMessage.Deserialize(message);
            }

            if (ReMessageType.IsMatch(rawMessage))
            {
                var id = rawMessage.First().ToString();
                if (System.Enum.TryParse(id, true, out SocketClientMessageTypes result))
                {
                    switch (result)
                    {
                        case SocketClientMessageTypes.Disconnect:
                            return DisconnectMessage.Deserialize(rawMessage);
                        case SocketClientMessageTypes.Connect:
                            return ConnectMessage.Deserialize(rawMessage);
                        case SocketClientMessageTypes.Heartbeat:
                            return new Heartbeat();
                        case SocketClientMessageTypes.Message:
                            return TextMessage.Deserialize(rawMessage);
                        case SocketClientMessageTypes.JSONMessage:
                            return JSONMessage.Deserialize(rawMessage);
                        case SocketClientMessageTypes.Event:
                            return EventMessage.Deserialize(rawMessage);
                        case SocketClientMessageTypes.ACK:
                            return AckMessage.Deserialize(rawMessage);
                        case SocketClientMessageTypes.Error:
                            return ErrorMessage.Deserialize(rawMessage);
                        case SocketClientMessageTypes.Noop:
                            return new NoopMessage();
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    Trace.WriteLine($"Message.Factory undetermined message: {rawMessage}");
                    return new TextMessage();
                }
            }

            if (rawMessage.IndexOf("[", StringComparison.Ordinal) > 0)
            {
                // int index = rawMessage.IndexOf("[");

                return AckMessage.Deserialize(rawMessage);
            }
            //if (rawMessage == "3")
            //{
            //    return new Heartbeat();
            //}
            else
            {
                Trace.WriteLine($"Message.Factory did not find matching message type: {rawMessage}");
                return new NoopMessage();
            }
        }
    }
}