namespace MVC_Task.Models
{
    public class MemberInfo
    {
        public int MemberId { get; set; }
        public decimal AmountOfMoney { get; set; }
        public string Name { get; set; }
        public bool IsMage { get; set; }
        public bool IsVampire { get; set; }

        public virtual Member MemberEntity { get; set; }
    }
}