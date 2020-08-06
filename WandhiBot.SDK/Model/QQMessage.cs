namespace WandhiBot.SDK.Model
{
    public class QQMessage
    {
        /// <summary>
        /// 消息体
        /// </summary>
        private string Text { set; get; }

        /// <summary>
        /// 重写默认ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}