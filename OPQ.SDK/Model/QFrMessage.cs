using OPQ.SDK.Enum;

namespace OPQ.SDK.Model
{
    /// <summary>
    /// 好友消息
    /// {"CurrentPacket":{"WebConnId":"","Data":{"FromUin":373884384,"ToUin":1213068777,"MsgType":"TextMsg","MsgSeq":22101,"Content":"123","RedBaginfo":null}},"CurrentQQ":1213068777}
    ///
    /// {"CurrentPacket":{"WebConnId":"","Data":{"FromUin":373884384,"ToUin":1213068777,"MsgType":"PicMsg","MsgSeq":22106,"Content":"{\"FriendPic\":[{\"FileMd5\":\"xdPjNQaMXis8ra+LwMzG0Q==\",\"FileSize\":1848,\"Path\":\"/373884384-2736833475-C5D3E335068C5E2B3CADAF8BC0CCC6D1\",\"Url\":\"http://c2cpicdw.qpic.cn/offpic_new/1213068777/373884384-2736833475-C5D3E335068C5E2B3CADAF8BC0CCC6D1/0\"}],\"Tips\":\"[好友图片]\"}","RedBaginfo":null}},"CurrentQQ":1213068777}
    /// </summary>
    public class QFrMessage
    {
        /// <summary>
        /// 来源qq
        /// </summary>
        public int FromUin { set; get; }
        /// <summary>
        /// 接收qq
        /// </summary>
        public long ToUin { set; get; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType MsgType { set; get; }
        /// <summary>
        /// 消息值
        /// </summary>
        public long MsgSeq { set; get; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { set; get; }
    }
}