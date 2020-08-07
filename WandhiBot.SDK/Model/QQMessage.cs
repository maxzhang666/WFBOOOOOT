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

        public static implicit operator string(QQMessage qqMessage)
        {
            return string.IsNullOrEmpty(qqMessage.Text) ? string.Empty : qqMessage.Text;
        }

        /// <summary>
        /// 确定两个指定的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 实例是否具有相同的值
        /// </summary>
        /// <param name="a">要比较的第一个对象</param>
        /// <param name="b">要比较的第二个对象</param>
        /// <returns>如果 a 是与 b 相同的值，或两者均为 <see langword="null" />，则为 <see langword="true" />；否则为 <see langword="false" /></returns>
        public static bool operator ==(QQMessage a, QQMessage b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// 确定两个指定的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 实例是否具有不同的值
        /// </summary>
        /// <param name="a">要比较的第一个对象</param>
        /// <param name="b">要比较的第二个对象</param>
        /// <returns>如果 a 是与 b 相同的值，或两者均为 <see langword="null" />，则为 <see langword="false" />；否则为 <see langword="true" /></returns>
        public static bool operator !=(QQMessage a, QQMessage b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// 确定指定的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 和 <see cref="T:System.String" /> 实例是否具有相同的值
        /// </summary>
        /// <param name="a">要比较的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 对象</param>
        /// <param name="b">要比较的 <see cref="T:System.String" /> 对象</param>
        /// <returns>如果 a.Text 是与 b 相同的值，或两者均为 <see langword="null" />，则为 <see langword="true" />；否则为 <see langword="false" /></returns>
        public static bool operator ==(QQMessage a, string b)
        {
            return a.Text.Equals(b);
        }

        /// <summary>
        /// 确定指定的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 和 <see cref="T:System.String" /> 实例是否具有不同的值
        /// </summary>
        /// <param name="a">要比较的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 对象</param>
        /// <param name="b">要比较的 <see cref="T:System.String" /> 对象</param>
        /// <returns>如果 a.Text 是与 b 相同的值，或两者均为 <see langword="null" />，则为 <see langword="false" />；否则为 <see langword="true" /></returns>
        public static bool operator !=(QQMessage a, string b)
        {
            return !a.Text.Equals(b);
        }

        /// <summary>
        /// 确定指定的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 和 <see cref="T:System.String" /> 实例是否具有相同的值
        /// </summary>
        /// <param name="a">要比较的 <see cref="T:System.String" /> 对象</param>
        /// <param name="b">要比较的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 对象</param>
        /// <returns>如果 a 是与 b.Text 相同的值，或两者均为 <see langword="null" />，则为 <see langword="true" />；否则为 <see langword="false" /></returns>
        public static bool operator ==(string a, QQMessage b)
        {
            return a.Equals(b.Text);
        }

        /// <summary>
        /// 确定指定的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 和 <see cref="T:System.String" /> 实例是否具有不同的值
        /// </summary>
        /// <param name="a">要比较的 <see cref="T:System.String" /> 对象</param>
        /// <param name="b">要比较的 <see cref="T:WandhiBot.Sdk.Model.QQMessage" /> 对象</param>
        /// <returns>如果 a 是与 b.Text 相同的值，或两者均为 <see langword="null" />，则为 <see langword="false" />；否则为 <see langword="true" /></returns>
        public static bool operator !=(string a, QQMessage b)
        {
            return !a.Equals(b.Text);
        }
    }
}