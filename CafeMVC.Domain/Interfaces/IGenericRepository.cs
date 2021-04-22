using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        void AddItem(T item);

        void DeleteItem(int id);

        void UpdateItem(T item);

        void Save();

        T GetItemById(int id);

        IQueryable<T> GetAllType();

        
    }
}
