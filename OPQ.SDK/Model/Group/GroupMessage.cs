using OPQ.SDK.Enum;

namespace OPQ.SDK.Model.Group
{
    public class GroupMessage:Message
    {
        public GroupMessage(long to,string content):base(to,content)
        {
            SendToType = SendToType.Group; 
        }
    }
}