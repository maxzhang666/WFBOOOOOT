using System;
using SocketClient.Message;

namespace SocketClient.Event
{
    public class MessageEventArgs:EventArgs
    {
        public IMessage Message { get; private set; }

        public MessageEventArgs(IMessage msg)
            : base()
        {
            this.Message = msg;
        }
    }
}