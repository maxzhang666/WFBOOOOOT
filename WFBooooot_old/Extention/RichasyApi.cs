using GHttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFBooooot.Extention
{
    public class RichasyApi
    {
        private string AppKey;
        private string AppSec;
        private string Scope;
        public RichasyApi(string appkey, string appsec, string scope = "wf.basic")
        {
            AppKey = appkey;
            AppSec = appsec;
            Scope = scope;
        }

        private string GetAccessToken()
        {
            var token = AppData.Cache.Get<string>("token", out var flag);
            if (!flag)
            {
                //Http.Post()
            }

            return token;
        }

    }
}
