namespace OPQ.SDK.Model
{
    public class OpqMessagePacket<T> where T : class
    {
        /// <summary>
        /// 链接Id
        /// </summary>
        public string WebConnId { get; set; }

        /// <summary>
        /// 消息详情
        /// </summary>
        public T Data { get; set; }
    }
}