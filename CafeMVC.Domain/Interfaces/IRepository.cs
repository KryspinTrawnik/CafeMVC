using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void AddItem(T item);

        void DeleteItem(int id);

        T GetItemById(int id);

        IQueryable<T> GetAllType()
    }
}
