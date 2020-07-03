using com.wandhi.wfbooooot.code.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Service
{
    public abstract class BaseService : IBaseService
    {
        long GroupId;
        string _Msg;
        public BaseService(long GroupId)
        {
            this.GroupId = GroupId;
        }
        public BaseService(long GroupId, string Msg)
        {
            this.GroupId = GroupId;
            this._Msg = Msg;
        }
        public BaseService()
        {

        }
        public abstract string GetMsg();
        public abstract string GetMsg(string KeyWord);

        /// <summary>
        /// 直接发送信息
        /// </summary>
        /// <param name="msg"></param>
        public async void send(string msg)
        {
            AppData.CQApi.SendGroupMessage(GroupId, msg);
        }
        /// <summary>
        /// 异步发送信息
        /// </summary>
        public async void send()
        {
            await Task.Factory.StartNew(async () =>
            {
                var msg = GetMsg();
                send(msg);
            });
        }
    }
}
