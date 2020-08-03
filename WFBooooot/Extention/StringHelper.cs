using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
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



        /// <summary> 
        /// 简体转换为繁体
        /// </summary> 
        /// <param name="str">简体字</param> 
        /// <returns>繁体字</returns> 
        public static string GetTraditional(this string str)
        {            
            return ChineseConverter.Convert(str, ChineseConversionDirection.SimplifiedToTraditional);
        }
        /// <summary> 
        /// 繁体转换为简体
        /// </summary> 
        /// <param name="str">繁体字</param> 
        /// <returns>简体字</returns> 
        public static string GetSimplified(this string str)
        {            
            return ChineseConverter.Convert(str, ChineseConversionDirection.TraditionalToSimplified);    
        }
    }
}
