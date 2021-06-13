using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public void AddNewAddress(AddressForCreationVm address, int customerId)
        {
            throw new NotImplementedException();
        }

        public void AddNewContactDetail(ContactDetailForViewVm contactDetail, int customerId)
        {
            throw new NotImplementedException();
        }

        public void AddNewCustomer(CustomerForCreationVm customer)
        {
            throw new NotImplementedException();
        }

        public void ChangeAddress(int address, int customerId)
        {
            throw new NotImplementedException();
        }

        public void ChangeContactDetails(int contactDetailId, int customerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(int address, int customerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerForListVm> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerForDashboardVm GetCustomerDashboard(int customerId)
        {
            throw new NotImplementedException();
        }

        public CustomerDetailsVm GetCustomerDetail(int customerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveContactDetail(int contactDetailId, int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
