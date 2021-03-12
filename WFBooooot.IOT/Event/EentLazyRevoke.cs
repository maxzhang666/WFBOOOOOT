using System;
using OPQ.SDK;
using WandhiBot.SDK.Model;

namespace WFBooooot.IOT.Event
{
    public class EventLazyRevoke : ILazyEvent
    {
        private readonly long _fromGroup;
        private readonly QQMessage _qqMessage;
        private readonly DateTime _time;

        public EventLazyRevoke(long fromGroup, QQMessage qqMessage, DateTime time)
        {
            _fromGroup = fromGroup;
            _qqMessage = qqMessage;
            _time = time;
        }

        public void Do()
        {
            AppData.OpqApi.RevokeMessage(_fromGroup, _qqMessage);
        }

        public bool CanDo()
        {
            return DateTime.Now > _time;
        }
    }
}