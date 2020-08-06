using WandhiBot.SDK.Model;

namespace WandhiBot.SDK.EventArgs
{
    public sealed class GroupMessageEventArgs : EventArgs
    {
        /// <summary>
        /// 来源QQ 
        /// </summary>
        public QQ FromQQ { set; get; }

        /// <summary>
        /// 来源群
        /// </summary>
        public Group FromGroup { set; get; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public QQMessage Msg { set; get; }
    }
}