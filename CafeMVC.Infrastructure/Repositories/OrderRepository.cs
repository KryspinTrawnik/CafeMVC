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

        public IQueryable<Order> GetAllOpenOrders()
        {
            return GetAllType().Where(x => x.HasBeenDone == false);

        }

        public IQueryable<Product> GetAllProductsFromOrder(int orderId)
        {
            return GetItemById(orderId).Products.AsQueryable();
        }

        public void AddOrChangeNote(int orderId, string note)
        {
            Order order = GetItemById(orderId);
            order.Note = note;
            UpdateItem(order);
        }
    }
}
