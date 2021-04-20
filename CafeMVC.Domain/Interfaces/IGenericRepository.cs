using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
