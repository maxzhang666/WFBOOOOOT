namespace WandhiBot.SDK.Model
{
    public class Group
    {
        public string Id { get; set; }

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