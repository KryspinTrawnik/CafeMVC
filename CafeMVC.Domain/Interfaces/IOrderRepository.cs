using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Interfaces
{
    public interface IOrderRepository 
    {
        IQueryable<Order> GetAllOpenOrders();

        IQueryable<Product> GetAllProductsFromOrder(int orderId);
        
        void AddOrChangeNote(int orderId, string note);
        
        Order GetOrderById(int orderId);

        void UpdateOrder(Order order);

        int AddNewOrder(Order order);

        void ChangeStatusOfOrder(int orderId, int statusId);

        IQueryable<Status> GetAllStatuses();

        IQueryable<Order> GetAllOrders();
    }
}
