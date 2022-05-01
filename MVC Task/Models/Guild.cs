using System.Collections.Generic;

namespace MVC_Task.Models
{
    public class Guild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}