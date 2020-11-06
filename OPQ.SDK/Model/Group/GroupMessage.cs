using System;
using OPQ.SDK.Enum;

namespace OPQ.SDK.Model.Group
{
    public class GroupMessage : Message
    {
        public GroupMessage(long to, string content) : base(to, content)
        {
            SendToType = SendToType.Group;
        }

        public GroupMessage(long to, string content, long atUser) : base(to, content)
        {
            this.AtUser = atUser;
            SendToType = SendToType.Group;
        }

        public GroupMessage(long to, Func<string> msgProcess) : base(to, msgProcess)
        {
            SendToType = SendToType.Group;
        }
    }
}