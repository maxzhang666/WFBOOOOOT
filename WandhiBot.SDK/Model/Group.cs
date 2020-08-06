namespace WandhiBot.SDK.Model
{
    public class Group
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 群名
        /// </summary>
        public string GroupName { get; set; }

        public override string ToString()
        {
            return Id;
        }

        public static implicit operator string(Group group)
        {
            return group.Id;
        }
    }
}