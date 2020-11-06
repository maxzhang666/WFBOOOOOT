namespace OPQ.SDK.Model
{
    public class OpqMessage<T> where T : class
    {
        /// <summary>
        /// 消息体
        /// </summary>
        public OpqMessagePacket<T> CurrentPacket { get; set; }

        /// <summary>
        /// 当前QQ
        /// </summary>
        public long CurrentQQ { get; set; }
    }
}