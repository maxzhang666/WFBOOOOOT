using System;
using System.Collections.Generic;

namespace WFBooooot.IOT.Helper
{
    public static class CommonHelper
    {
        /// <summary>
        /// 简单的验证表达式
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static string CheckCode(out string res)
        {
            var a = new Random().Next(0, 100);
            var b = new Random(a).Next(0, 100);

            res = $"{a + b}";

            return $"{a}+{b} = ?";
        }
    }
}