namespace OPQ.SDK.Enum
{
    public enum CommonEventType
    {
        /// <summary>
        /// 加群事件
        /// </summary>
        ON_EVENT_GROUP_JOIN,

        /// <summary>
        /// 管理员变更
        /// </summary>
        ON_EVENT_GROUP_ADMIN,

        /// <summary>
        /// 退群
        /// </summary>
        ON_EVENT_GROUP_EXIT,

        /// <summary>
        /// 主动退群成功事件
        /// </summary>
        ON_EVENT_GROUP_EXIT_SUCC,

        /// <summary>
        /// 踢出
        /// </summary>
        ON_EVENT_GROUP_ADMINSYSNOTIFY,

        /// <summary>
        /// 消息撤回
        /// </summary>
        ON_EVENT_GROUP_REVOKE,

        /// <summary>
        /// 群禁言
        /// </summary>
        ON_EVENT_GROUP_SHUT
    }
}