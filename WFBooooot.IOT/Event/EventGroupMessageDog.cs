using System;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Helper;
using WFBooooot.IOT.Service;

namespace WFBooooot.IOT.Event
{
    public class EventGroupMessageDog : IGroupMessageEvent
    {
        private CacheHelper _cacheHelper;
        private const string Key = "dog";

        public EventGroupMessageDog(CacheHelper cacheHelper)
        {
            _cacheHelper = cacheHelper;
        }

        public void GroupMessage(GroupMessageEventArgs e)
        {
            var last = _cacheHelper.Get<DateTime>(Key);
            if (e.Msg.Text.Contains("舔狗") && (last == null || DateTime.Now - last > TimeSpan.FromMinutes(5)))
            {
                var msg = new DogService(e.FromGroup).GetMsg();
                if (msg.IsNotEmpty())
                {
                    AppData.OpqApi.SendGroupMessage(e.FromGroup, msg);
                }
            }
        }
    }
}