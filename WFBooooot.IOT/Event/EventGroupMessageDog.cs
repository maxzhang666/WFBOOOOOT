using System;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Helper;
using WFBooooot.IOT.Helper.Interface;
using WFBooooot.IOT.Service;

namespace WFBooooot.IOT.Event
{
    public class EventGroupMessageDog : IGroupMessageEvent
    {
        private readonly ICacheService _cacheService;
        private const string Key = "dog";

        public EventGroupMessageDog(ICacheService cacheHelper)
        {
            _cacheService = cacheHelper;
        }

        public void GroupMessage(GroupMessageEventArgs e)
        {
            var last = _cacheService.Get<DateTime>(Key);
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