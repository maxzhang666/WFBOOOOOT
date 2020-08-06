namespace WandhiBot.SDK.Model
{
    public class QQ
    {
        /// <summary>
        /// QQ号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        public override string ToString()
        {
            return Id;
        }

        public static implicit operator string(QQ qq)
        {
            return qq.ToString();
        }
    }
}