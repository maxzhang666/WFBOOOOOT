using WFBooooot.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFBooooot.Service
{
    public class DjtService : BaseService
    {
        const string Api = "https://du.shadiao.app/api.php";
        public DjtService(long GroupId) : base(GroupId)
        {

        }
        public DjtService()
        {

        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public override string GetMsg()
        {
            return GHttpHelper.Http.Get(Api);
        }

        public override string GetMsg(string KeyWord)
        {
            throw new NotImplementedException();
        }
    }
}
