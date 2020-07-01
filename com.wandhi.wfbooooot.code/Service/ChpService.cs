﻿using com.wandhi.wfbooooot.code.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Service
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
    }
}
