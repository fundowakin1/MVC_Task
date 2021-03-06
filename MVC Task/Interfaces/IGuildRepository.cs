using MVC_Task.Models;

namespace MVC_Task.Interfaces
{
    public interface IGuildRepository : IRepository<Guild>
    {
        public Guild GetOneByName(string name);
    }
}
