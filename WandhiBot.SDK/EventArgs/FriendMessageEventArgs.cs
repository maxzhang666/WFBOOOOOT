using WandhiBot.SDK.Model;

namespace WandhiBot.SDK.EventArgs
{
    /// <summary>
    /// 好友消息
    /// </summary>
    public sealed class FriendMessageEventArgs : EventArgs
    {
        /// <summary>
        /// 来源QQ 
        /// </summary>
        public QQ FromQQ { set; get; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public QQMessage Msg { set; get; }
    }
}