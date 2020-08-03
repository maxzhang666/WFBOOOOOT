using WFBooooot.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFBooooot.Service
{
    public class ChpService : BaseService
    {

        public ChpService(long send) : base(send)
        {

        }
        public ChpService()
        {

        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public override string GetMsg()
        {
            return GHttpHelper.Http.Get("https://chp.shadiao.app/api.php");
        }

        public override string GetMsg(string KeyWord)
        {
            throw new NotImplementedException();
        }
    }
}
