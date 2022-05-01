namespace MVC_Task.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int GuildId { get; set; }
        public virtual Guild GuildEntity { get; set; }
        public virtual MemberInfo MemberInfoEntity { get; set; }
    }
}