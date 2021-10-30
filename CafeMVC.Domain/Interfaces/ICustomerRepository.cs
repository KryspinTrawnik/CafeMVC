using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Interfaces
{
    public interface ICustomerRepository 
    {
        Customer GetCustomerById(int id);

        void UpdateCustomer(Customer customer);

        IQueryable<Order> GetOrdersByCustomer(int customerId);

        int AddNewAddress(Address address);

        int AddNewContactDetail(ContactDetail contactDetail);

        Address GetAddressById(int addressId);

        IQueryable<AddressType> GetAllAddressTypes();

        IQueryable<ContactDetailType> GetAllContactDetailTypes();

        int AddNewCustomer(Customer customer);

        void UpdateAddress(Address address);

        void UpdateContactDetail(ContactDetail contactDetail);

        void DeleteAddress(int addressId);

        IQueryable<Customer> GetAllCustomers();

        void DeleteCustomer(int customerId);

        void DeleteContactDetail(int contactDetailId);
    }
}
