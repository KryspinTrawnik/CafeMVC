using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
    }
}
