namespace WandhiBot.SDK.Enum
{
    public enum MessageEventType
    {
        /// <summary>群消息</summary>
        GroupMessage = 2,
        /// <summary>讨论组消息</summary>
        DiscussMessage = 4,
        /// <summary>群文件上传</summary>
        GroupFileUpload = 11, // 0x0000000B
        /// <summary>私聊消息</summary>
        PrivateMessage = 21, // 0x00000015
        /// <summary>群管理变动</summary>
        GroupManageChange = 101, // 0x00000065
        /// <summary>群成员减少</summary>
        GroupMemberDecrease = 102, // 0x00000066
        /// <summary>群成员增加</summary>
        GroupMemberIncrease = 103, // 0x00000067
        /// <summary>群成员禁言</summary>
        GroupMemberBanSpeak = 104, // 0x00000068
        /// <summary>好友添加</summary>
        FriendAdd = 201, // 0x000000C9
        /// <summary>好友添加请求</summary>
        FriendAddRequest = 301, // 0x0000012D
        /// <summary>群添加请求</summary>
        GroupAddRequest = 302, // 0x0000012E
    }
}