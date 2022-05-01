using System.Collections.Generic;
using System.Linq;
using MVC_Task.Contexts;
using MVC_Task.Interfaces;
using MVC_Task.Models;

namespace MVC_Task.Repositories
{
    public class MemberInfoRepository : IMemberInfoRepository
    {
        private static GuildContext _context;

        public MemberInfoRepository(GuildContext context)
        {
            _context ??= context;
        }
        public IEnumerable<MemberInfo> GetAll()
        {
            return _context.MembersInfo;
        }

        public MemberInfo GetOne(int id)
        {
            return _context.MembersInfo.FirstOrDefault(memberInfo => memberInfo.MemberId==id);
        }
    }
}
