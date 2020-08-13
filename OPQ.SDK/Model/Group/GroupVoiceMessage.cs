using OPQ.SDK.Enum;

namespace OPQ.SDK.Model.Group
{
    public class GroupVoiceMessage:VoiceMessage
    {
        public GroupVoiceMessage(long to,string content,string voiceUrl,string voiceBase64Buf):base(to,content,voiceUrl,voiceBase64Buf)
        {
            SendToType = SendToType.Group;
        }
    }
}