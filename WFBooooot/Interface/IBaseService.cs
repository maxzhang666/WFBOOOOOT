using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Interface
{
    interface IBaseService
    {
        /// <summary>
        /// 发送指定消息
        /// </summary>
        /// <param name="msg"></param>
        void send(string msg);
        /// <summary>
        /// 自动获取并发送消息
        /// </summary>
        void send();

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <returns></returns>
        string GetMsg();
    }
}
