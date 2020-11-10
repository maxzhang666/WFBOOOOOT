using OPQ.SDK.Enum;

namespace OPQ.SDK.Model.Group
{
    public class GroupImgMessage : ImgMessage
    {
        public GroupImgMessage(long to, string content, string picUrl, string picBase64Buf = "", string fileMd5 = "") : base(to, content, picUrl, picBase64Buf, fileMd5)
        {
            SendToType = SendToType.Group;
        }

        public GroupImgMessage(long to, string content, string picUrl, bool flashPic, string picBase64Buf = "", string fileMd5 = "") : base(to, content, picUrl, flashPic, picBase64Buf, fileMd5)
        {
            SendToType = SendToType.Group;
        }
    }
}