using CafeMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerForListVm> GetAllCustomers();

        CustomerDetailsVm GetCustomerDetail(int customerId);

        CustomerForDashboardVm GetCustomerDashboard(int customerId);

        void AddNewCustomer(CustomerForCreationVm customer);

        void DeleteCustomer(int customerId);

        void AddNewContactDetail(ContactInfoForCreationVm contactDetail, int customerId);

        void ChangeContactDetails(int contactDetailId, int customerId);

        void RemoveContactDetail(int contactDetailId, int customerId);

        void AddNewAddress(AddressForCreationVm address, int customerId);

        void ChangeAddress(int address, int customerId);

        void DeleteAddress(int address, int customerId);
    }
}
