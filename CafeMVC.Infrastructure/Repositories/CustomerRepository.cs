using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context) : base(context)
        {
        }

        public IQueryable<Order> GetOrdersByCustomer(int customerId)
        {
            return GetItemById(customerId).Orders.AsQueryable();  
        }
    }
}
