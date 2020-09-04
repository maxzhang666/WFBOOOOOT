using System.Threading.Tasks;
using WandhiHelper.Extension;

namespace WFBooooot.IOT.Service
{
    public abstract class BaseService : IBaseService
    {
        protected long GroupId;
        protected string _Msg;
        protected string _Keyword;
        protected long _MemberId;

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

        public abstract string GetMsg();
        public abstract string GetMsg(string KeyWord);

        /// <summary>
        /// 直接发送信息
        /// </summary>
        /// <param name="msg"></param>
        public async void send(string msg)
        {
        }

        /// <summary>
        /// 异步发送信息
        /// </summary>
        public async void send()
        {
            Task.Factory.StartNew(async () =>
            {
                var msg = GetMsg(_Keyword);
                if (!msg.IsEmpty())
                {
                    send(msg);
                }
            });
        }
    }
}