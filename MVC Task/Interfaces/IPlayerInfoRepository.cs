using MVC_Task.Models;

namespace MVC_Task.Interfaces
{
    public interface IPlayerInfoRepository : IRepository<PlayerInfo>
    {
        public void Add(PlayerInfo playerInfo);
    }
}
