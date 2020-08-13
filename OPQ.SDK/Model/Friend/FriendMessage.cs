using OPQ.SDK.Enum;

namespace OPQ.SDK.Model.Friend
{
    public class FriendMessage:Message
    {
        public FriendMessage(long to,string content):base(to,content)
        {
            SendToType = SendToType.Friend; 
        }
    }
}