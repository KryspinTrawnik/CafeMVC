using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IQueryable<Order> GetAllOpenOrders();

        void ChangeNote(int orderId, string annotation);

        IQueryable<Product> GetAllProductsFromOrder(int orderId);


    }
}
