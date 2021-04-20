using CafeMVC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> table;

        public GenericRepository(Context context)
        {
            this._context = context;
            table = context.Set<T>();
        }
        public void AddItem(T item)
        {
            table.Add(item);
        }

        public void DeleteItem(int id)
        {
            T existitng = table.Find(id);
            table.Remove(existitng);
        }

        public IQueryable<T> GetAllType()
        {
            return (IQueryable<T>)table.ToList();
        }

        public T GetItemById(int id)
        {
            return table.Find(id);
        }

        public void UpdateItem(T item)
        {
            table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;

        }

        void IGenericRepository<T>.Save()
        {
            _context.SaveChanges();
        }
    }
}
