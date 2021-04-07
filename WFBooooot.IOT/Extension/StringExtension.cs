using Castle.Core.Internal;
using WandhiBot.SDK.Model;

namespace WFBooooot.IOT.Extension
{
    public static class StringExtension
    {
        public static string Format(this string source)
        {
            return source.Replace(" ", "").ToLower().Trim();
        }

        public static bool IsNotEmpty(this string str)
        {
            return !str.IsNullOrEmpty();
        }

        /// <summary>
        /// 生成艾特用户的红字符
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static string AtUser(QQ qq)
        {
            return $"[ATUSER({qq})]";
        }
    }
}