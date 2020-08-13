namespace OPQ.SDK.Model
{
    public class OpqMessagePacket
    {
        /// <summary>
        /// 链接Id
        /// </summary>
        public string WebConnId { get; set; }

        /// <summary>
        /// 消息详情
        /// </summary>
        public QMessage Data { get; set; }
    }
}