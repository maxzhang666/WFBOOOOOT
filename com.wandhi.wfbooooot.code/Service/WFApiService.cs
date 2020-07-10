using com.wandhi.wfbooooot.code.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Service
{
    public class WFService : BaseService, IBaseService
    {
        const string AppKey = "567a41280a304183833fe5e6c063a87d";
        const string AppSec = "97b93cece9fe49518ea2b508f1d746ac";
        const string Scope = "wfa.basic";

        
        
        public override string GetMsg()
        {
            throw new NotImplementedException();
        }

        public override string GetMsg(string KeyWord)
        {
            throw new NotImplementedException();
        }


    }
}
