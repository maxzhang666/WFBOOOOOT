using WandhiBot.SDK.Model;

namespace WandhiBot.SDK.EventArgs
{
    public sealed class GroupMessageEventArgs : EventArgs
    {
        /// <summary>
        /// 来源QQ 
        /// </summary>
        public QQ fromQQ { set; get; }

        /// <summary>
        /// 来源群
        /// </summary>
        public Group fromGroup { set; get; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public QQMessage msg { set; get; }
    }
}