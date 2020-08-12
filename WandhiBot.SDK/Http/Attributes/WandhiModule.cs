using System;
using WandhiBot.SDK.Enum;

namespace WandhiBot.SDK.Http.Attributes
{
    /// <summary>
    /// 特性标记-模块-类
    /// </summary>

    public interface IWandhiModule
    {
        /// <summary>
        /// 服务器根路径
        /// </summary>
        /// <returns></returns>
        string GetRoot();
    }
}