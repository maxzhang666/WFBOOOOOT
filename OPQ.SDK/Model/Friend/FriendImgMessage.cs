using OPQ.SDK.Enum;

namespace OPQ.SDK.Model.Friend
{
    public class FriendImgMessage : ImgMessage
    {
        public FriendImgMessage(long to, string content, string picUrl, string picBase64Buf, string fileMd5) : base(to, content, picUrl, picBase64Buf, fileMd5)
        {
            SendToType = SendToType.Friend;
        }
    }
}