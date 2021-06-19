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

        public IQueryable<Order> GetAllNotDoneOrders()
        {
            return GetAllType().Where(x => x.HasBeenDone == false);

        }

        void IOrderRepository.ChangeNote(int orderId, string note)
        {
            GetItemById(orderId).Note = note;
            _context.SaveChanges();
        }
    }
}
