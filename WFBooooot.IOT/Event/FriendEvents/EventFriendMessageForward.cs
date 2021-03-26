using System;
using OPQ.SDK;
using OPQ.SDK.Model.Friend;
using WandhiBot.SDK.Enum;
using WandhiBot.SDK.Event;
using WandhiBot.SDK.EventArgs;

namespace WFBooooot.IOT.Event.FriendEvents
{
    public class EventFriendMessageForward : IFriendMessageEvent
    {
        /// <summary>
        /// 消息转发
        /// </summary>
        /// <param name="e"></param>
        public void FriendMessage(FriendMessageEventArgs e)
        {
            AppData.OpqApi.SendMessage(new FriendMessage(373884384, e.Msg));
        }
    }
}