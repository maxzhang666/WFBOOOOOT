using OPQ.SDK.Enum;

namespace OPQ.SDK.Model
{
    public class VoiceMessage : Message
    {
        /// <summary>
        /// 音频Url
        /// 音频大小控制在1m voiceUrl 和voiceBase64Buf 二选一
        /// </summary>
        public string VoiceUrl { get; set; }

        /// <summary>
        /// 经过base64的音频buf
        /// 音频大小控制在1m voiceUrl 和voiceBase64Buf 二选一
        /// </summary>
        public string VoiceBase64Buf { get; set; }

        public VoiceMessage(long to, string content, string voiceUrl, string voiceBase64Buf) : base(to, content)
        {
            if (string.IsNullOrEmpty(voiceUrl))
            {
                VoiceBase64Buf = voiceBase64Buf;
            }
            else
            {
                VoiceUrl = voiceUrl;
            }

            SendMsgType = MessageType.VoiceMsg;
        }
    }
}