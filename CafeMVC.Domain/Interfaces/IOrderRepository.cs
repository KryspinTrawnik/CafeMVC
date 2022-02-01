using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IOrderRepository 
    {
        IQueryable<Order> GetAllOpenOrders();

        IQueryable<OrderProduct> GetAllProductsFromOrder(int orderId);
        
        void AddOrChangeNote(int orderId, string note);
        
        Order GetOrderById(int orderId);

        void UpdateOrder(Order order);

        int AddNewOrder(Order order);

        void ChangeStatusOfOrder(int orderId, int statusId);

        IQueryable<Status> GetAllStatuses();

        IQueryable<Order> GetAllOrders();
    }
}
