using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public IQueryable<Order> GetOrdersByUser(int userId)
        {
            return GetItemById(userId).Orders.AsQueryable();  
        }
    }
}
