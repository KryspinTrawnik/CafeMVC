using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        int AddItem(T item);

        void DeleteItem(int id);

        void UpdateItem(T item);

        void Save();

        T GetItemById(int id);

        IQueryable<T> GetAllType();
    }
}
