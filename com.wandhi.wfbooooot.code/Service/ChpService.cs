using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Service
{
    public class ChpService
    {
        public long send;
        public ChpService(long send)
        {
            this.send = send;
        }
        public ChpService()
        {

        }
        public void run()
        {
            AppData.CQApi.SendGroupMessage(send, GetMsg());
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public string GetMsg()
        {
            return GHttpHelper.Http.Get("https://chp.shadiao.app/api.php");
        }
    }
}
