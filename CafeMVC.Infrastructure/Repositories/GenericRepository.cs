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
        public int AddItem(T item)
        {
            table.Add(item);
            Save();
            return (int)item.GetType().GetProperty("Id").GetValue(item, null);
        }

        public void DeleteItem(int id)
        {
            T existitng = table.Find(id);
            table.Remove(existitng);
            Save();
        }

        public IQueryable<T> GetAllType()
        {
            return table.AsQueryable();
        }

        public T  GetItemById(int id)
        {

            return table.IncludeAll().AsEnumerable()
                .FirstOrDefault(x=>(int)x.GetType().GetProperty("Id").GetValue(x) == id);
        }

        public void UpdateItem(T item)
        {
            table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            Save();

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        

    }
}
