using System.Collections.Generic;
using System.Linq;
using MVC_Task.Contexts;
using MVC_Task.Interfaces;
using MVC_Task.Models;

namespace MVC_Task.Repositories
{
    public class GuildRepository : IGuildRepository
    {
        private static GuildContext _context;

        public GuildRepository(GuildContext context)
        {
            _context ??= context;
        }

        public IEnumerable<Guild> GetAll()
        {
            return _context.Guilds;
        }

        public Guild GetOne(int id)
        {
            return _context.Guilds.FirstOrDefault(guild => guild.Id == id);
        }

        public Guild GetOneByName(string name)
        {
            return _context.Guilds.FirstOrDefault(guild => guild.Name == name);
        }
    }
}
