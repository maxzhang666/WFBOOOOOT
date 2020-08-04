using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFBooooot.Interface;

namespace WFBooooot.Service
{
    public abstract class BaseService : IBaseService
    {
        long GroupId;
        string _Msg;
        string _Keyword;
        long _MemberId;
        public BaseService(long GroupId)
        {
            this.GroupId = GroupId;
        }
        public BaseService(long GroupId, long MemberId, string Keyword)
        {
            this.GroupId = GroupId;
            this._MemberId = MemberId;
            this._Keyword = Keyword;
        }
        public BaseService(long GroupId, long MemberId, string Keyword, string Msg)
        {
            this.GroupId = GroupId;
            this._Keyword = Keyword;
            this._Msg = Msg;
            this._MemberId = MemberId;
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
                var msg = GetMsg(_Keyword);
                send(msg);
            });
        }
    }
}
