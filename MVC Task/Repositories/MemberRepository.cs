using System.Collections.Generic;
using System.Linq;
using MVC_Task.Contexts;
using MVC_Task.Interfaces;
using MVC_Task.Models;

namespace MVC_Task.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private static GuildContext _context;

        public MemberRepository(GuildContext context)
        {
            _context ??= context;
        }
        public IEnumerable<Member> GetAll()
        {
            return _context.Members;
        }

        public Member GetOne(int id)
        {
            return _context.Members.FirstOrDefault(member => member.Id==id);
        }
    }
}
