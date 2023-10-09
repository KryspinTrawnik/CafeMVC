using CafeMVC.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Interfaces
{
    public interface IOrderRepository 
    {
        IQueryable<Order> GetOpenOrders();

        IQueryable<OrderedProductDetails> GetAllProductsFromOrder(int orderId);
        
        void AddOrChangeNote(int orderId, string note);
        
        Order GetOrderById(int orderId);

        void UpdateOrder(Order order);

        int AddNewOrder(Order order);

        void ChangeStatusOfOrder(int orderId, int statusId);

        IQueryable<Status> GetAllStatuses();

        IQueryable<Order> GetAllOrders();

        IQueryable<PaymentType> GetAllPaymenTypes();

        IQueryable<Address> GetAllAddressesFromOrder(int orderId);

        IQueryable<ContactDetail> GetAllContactDetailsFromOrder(int orderId);
       
        IQueryable<Order> GetClosedOrders();
        Task<List<Order>> GetCustomerOrders(int customerId);
    }
}
