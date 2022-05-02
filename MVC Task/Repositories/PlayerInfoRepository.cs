using System.Collections.Generic;
using System.Linq;
using MVC_Task.Contexts;
using MVC_Task.Interfaces;
using MVC_Task.Models;

namespace MVC_Task.Repositories
{
    public class PlayerInfoRepository : IPlayerInfoRepository
    {
        private static PlayerContext _context;

        public PlayerInfoRepository(PlayerContext context)
        {
            _context ??= context;
        }
        public IEnumerable<PlayerInfo> GetAll()
        {
            return _context.PlayersInfo;
        }

        public PlayerInfo GetOne(int id)
        {
            return _context.PlayersInfo.FirstOrDefault(playerInfo => playerInfo.PlayerId == id);
        }

        public void Add(PlayerInfo playerInfo)
        {
            _context.PlayersInfo.Add(playerInfo);
            _context.SaveChanges();
        }
    }
}
