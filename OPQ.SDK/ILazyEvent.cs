using System;

namespace OPQ.SDK
{
    /// <summary>
    /// 延时事件
    /// </summary>
    public interface ILazyEvent
    {
        /// <summary>
        /// 执行
        /// </summary>
        public void Do();

        /// <summary>
        /// 执行条件
        /// </summary>
        /// <returns></returns>
        public bool CanDo();
    }
}