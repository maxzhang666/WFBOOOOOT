using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Extention
{
    public static class StringHelper
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 是否非空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string str)
        {
            return !str.IsEmpty();
        }

        public static bool IsNotEmpty<T>(this List<T> list)
        {
            return list != null && list.Count > 0;
        }

        public static bool IsEmpty<T>(this List<T> list)
        {
            return !list.IsNotEmpty();
        }
    }
}
