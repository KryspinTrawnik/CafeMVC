using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System.Linq;

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

        public void AddNewAddress(Address address, int customerId)
        {
            Customer customer = GetItemById(customerId);
            customer.Addresses.Add(address);
            UpdateItem(customer);

        }

        public void AddNewCustomerContactInfo(CustomerContactInformation contactDetail, int customerId)
        {
            Customer customer = GetItemById(customerId);
            customer.UserContactInformations.Add(contactDetail);
            UpdateItem(customer);
        }

        public Address GetCustomerAddressById(int customerId, int addressId)
        {
            Address address = GetItemById(customerId).Addresses.FirstOrDefault(x => x.Id == addressId);

            return address;
        }
    }
}
