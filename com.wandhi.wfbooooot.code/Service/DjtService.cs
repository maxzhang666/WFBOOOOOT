using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Service
{
    public class DjtService
    {
        const string Api = "https://du.shadiao.app/api.php";

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public string GetMsg()
        {
            return GHttpHelper.Http.Get(Api);
        }
    }
}
