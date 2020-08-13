using OPQ.SDK.Enum;

namespace OPQ.SDK.Model.Friend
{
    public class FriendVoiceMessage:VoiceMessage
    {
        public FriendVoiceMessage(long to,string content,string voiceUrl,string voiceBase64Buf):base(to,content,voiceUrl,voiceBase64Buf)
        {
            SendToType = SendToType.Friend;
        }
    }
}