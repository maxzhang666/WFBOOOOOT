namespace OPQ.SDK.Model
{
    public class OpqMessage
    {
        /// <summary>
        /// 消息体
        /// </summary>
        public OpqMessagePacket CurrentPacket { get; set; }

        /// <summary>
        /// 当前QQ
        /// </summary>
        public long CurrentQQ { get; set; }
    }
}