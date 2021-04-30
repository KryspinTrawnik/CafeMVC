using CafeMVC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CafeMVC.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly Context _context;
        public readonly DbSet<T> table;

        public GenericRepository(Context context)
        {
            this._context = context;
            table = context.Set<T>();
        }
        public void AddItem(T item)
        {
            table.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            T existitng = table.Find(id);
            table.Remove(existitng);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAllType()
        {
            return table;
        }

        public T GetItemById(int id)
        {
            return table.Find(id);
        }

        public void UpdateItem(T item)
        {
            table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

        }

        void IGenericRepository<T>.Save()
        {
            _context.SaveChanges();
        }
    }
}
