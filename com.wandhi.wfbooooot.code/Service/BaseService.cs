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
        public BaseService(long GroupId)
        {
            this.GroupId = GroupId;
        }
        public BaseService()
        {

        }
        public abstract string GetMsg();

        public void send(string msg)
        {
            AppData.CQApi.SendGroupMessage(GroupId, msg);

        }

        public async void send()
        {
            await Task.Run(() =>
            {
                var msg = GetMsg();
                send(msg);
            });
        }
    }
}
