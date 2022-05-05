using System.Collections.Generic;
using System.Linq;
using MVC_Task.Contexts;
using MVC_Task.Interfaces;
using MVC_Task.Models;

namespace MVC_Task.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private static PlayerContext _context;

        public PlayerRepository(PlayerContext context)
        {
            _context ??= context;
        }
        public IEnumerable<Player> GetAll()
        {
            return _context.Players;
        }

        public Player GetOne(int id)
        {
            return _context.Players.FirstOrDefault(player => player.Id == id);
        }
        public void Add(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }
    }
}
