using WandhiBot.SDK.Model;

namespace WandhiBot.SDK.EventArgs
{
    /// <summary>
    /// 加群事件
    /// </summary>
    public sealed class GroupJoinEventArgs : EventArgs
    {
        /// <summary>
        /// 来源QQ 
        /// </summary>
        public QQ FromQQ { set; get; }

        /// <summary>
        /// 来源群
        /// </summary>
        public Group FromGroup { set; get; }
    }
}