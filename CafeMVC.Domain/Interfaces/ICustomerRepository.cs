using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IQueryable<Order> GetOrdersByCustomer(int customerId);

        void AddNewAddress(Address address, int customerId);

        void AddNewCustomerContactInfo(CustomerContactInformation contactDetail, int customerId);
    }
}
