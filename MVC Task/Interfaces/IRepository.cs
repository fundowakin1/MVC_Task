using System.Collections.Generic;

namespace MVC_Task.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(int id);
    }
}
