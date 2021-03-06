using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface ICustomerRepository 
    {
        ///***custommer aciton***///
        int AddNewCustomer(Customer customer);

        Customer GetCustomerById(int id);

        void UpdateCustomer(Customer customer);

        IQueryable<Order> GetOrdersByCustomer(int customerId);

        void DeleteCustomer(int customerId);
        IQueryable<Customer> GetAllCustomers();
        ///***Address Actionas***///
        int AddNewAddress(Address address);

        Address GetAddressById(int addressId);

        IQueryable<AddressType> GetAllAddressTypes();

        void UpdateAddress(Address address);

        void DeleteAddress(int addressId);
        ///*** ContactDetail Actions***/

        int AddNewContactDetail(ContactDetail contactDetail);

        IQueryable<ContactDetailType> GetAllContactDetailTypes();

        void UpdateContactDetail(ContactDetail contactDetail);

        void DeleteContactDetail(int contactDetailId);
        
        ContactDetail GetContactDetailById(int contactDetailId);
    }
}
