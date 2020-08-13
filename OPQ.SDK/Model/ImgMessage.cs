using OPQ.SDK.Enum;

namespace OPQ.SDK.Model
{
    public class ImgMessage : Message
    {
        /// <summary>
        /// 图片Url网络地址
        /// 图片大小控制在1m picUrl 和picBase64Buf 二选一 优先处理fileMd5字段
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 经过base64的图片buf
        /// 图片大小控制在1m picUrl 和picBase64Buf 二选一 优先处理fileMd5字段
        /// </summary>
        public string PicBase64Buf { get; set; }

        /// <summary>
        /// 经过base64处理过
        /// 图片大小控制在1m picUrl 和picBase64Buf 二选一 优先处理fileMd5字段
        /// </summary>
        public string FileMd5 { get; set; }

        public ImgMessage(long to, string content, string picUrl, string picBase64Buf, string fileMd5) : base(to, content)
        {
            if (string.IsNullOrEmpty(picUrl))
            {
                PicBase64Buf = picBase64Buf;
            }
            else
            {
                PicUrl = picUrl;
            }

            FileMd5 = fileMd5;

            SendMsgType = MessageType.PicMsg;
        }
    }
}