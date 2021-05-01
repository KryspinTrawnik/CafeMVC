using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }

        public IQueryable<Order> GetNotDoneOrders()
        {
            return GetAllType().Where(x => x.HasBeenDone == false);

        }
    }
}
