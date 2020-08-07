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

        public static bool operator !=(Group a, Group b)
        {
            if (a == null && b == null)
            {
                return false;
            }

            if (a == null || b == null)
            {
                return true;
            }

            return a.Id != b.Id;
        }

        public static bool operator ==(Group a, Group b)
        {
            return !(a != b);
        }
    }
}