using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CafeMVC.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }
        
        //////Costumer actions//////
        
        public Customer GetCustomerById(int id)
        {
            Customer customer = _context.Customers.AsNoTracking()
                .Include(e => e.Addresses).ThenInclude(e => e.AddressType)
                .Include(e => e.ContactDetails).ThenInclude(e => e.ContactDetailType)
                .Include(e => e.Orders).ThenInclude(e => e.OrderedProductsDetails)
                .FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).Property("FirstName").IsModified = true;
            _context.Entry(customer).Property("Surname").IsModified = true;
            _context.Entry(customer).Collection("Addresses").IsModified = true;
            _context.Entry(customer).Collection("ContactDetails").IsModified = true;
            _context.Entry(customer).Collection("Orders").IsModified = true;
            _context.SaveChanges();
        }

        public IQueryable<Order> GetOrdersByCustomer(int customerId)=> GetCustomerById(customerId).Orders.AsQueryable();
    
        public int AddNewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public IQueryable<Customer> GetAllCustomers()=>_context.Customers.AsNoTracking();
       
        //////Address Actions/////////

        public int AddNewAddress(Address address)
        {
            _context.Adresses.Add(address);
            _context.SaveChanges();
            return address.Id;
        }

        public Address GetAddressById(int addressId)
        {
            Address address = _context.Adresses.AsNoTracking()
                .Include(e => e.AddressType)
                .FirstOrDefault(x => x.Id == addressId);
            return address;
        }

        public IQueryable<AddressType> GetAllAddressTypes()=>_context.AddressTypes.AsNoTracking();


        public void UpdateAddress(Address address)
        {
            _context.Attach(address);
            _context.Entry(address).Property("BuildingNumber").IsModified = true;
            _context.Entry(address).Property("FlatNumber").IsModified = true;
            _context.Entry(address).Property("Street").IsModified = true;
            _context.Entry(address).Property("City").IsModified = true;
            _context.Entry(address).Property("ZipCode").IsModified = true;
            _context.Entry(address).Property("Country").IsModified = true;
            _context.Entry(address).Reference("AddressType").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteAddress(int addressId)
        {
            Address address = _context.Adresses.FirstOrDefault(a => a.Id == addressId);
            if (address != null)
            {
                _context.Adresses.Remove(address);
                _context.SaveChanges();
            }
        }
        public IQueryable<Address> GetAllAddressesFromOrder(int orderId) =>_context.OrderAddresses
            .Where(x => x.OrderId == orderId).Select(y => y.Address);

        //////ContactDetails actions//////
        
        public int AddNewContactDetail(ContactDetail contactDetail)
        {
            _context.ContactDetails.Add(contactDetail);
            _context.SaveChanges();
            return contactDetail.Id;
        }


        public IQueryable<ContactDetailType> GetAllContactDetailTypes()=> _context.ContactDetailTypes.AsNoTracking();

        public void UpdateContactDetail(ContactDetail contactDetail)
        {
            _context.Attach(contactDetail);
            _context.Entry(contactDetail).Property("ContactDetailInformation").IsModified = true;
            _context.Entry(contactDetail).Property("ContactDetailTypeId").IsModified = false;
            _context.SaveChanges();
        }

        public void DeleteContactDetail(int contactDetailId)
        {
            ContactDetail contactDetail = _context.ContactDetails.FirstOrDefault(x => x.Id == contactDetailId);
            if (contactDetail != null)
            {
                _context.ContactDetails.Remove(contactDetail);
                _context.SaveChanges();
            }
        }

        public ContactDetail GetContactDetailById(int contactDetailId)
        {
            return _context.ContactDetails.AsNoTracking().Include(x =>x.ContactDetailType)
                .FirstOrDefault(x => x.Id == contactDetailId);

        }

        public IQueryable<ContactDetail> GetAllContactDetailsFromOrder(int orderId) => 
            _context.OrderContactDetails.Where(x => x.OrderId == orderId).Select(y => y.ContactDetail);
    }
}
