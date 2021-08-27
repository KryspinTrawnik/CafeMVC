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
        ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString);

        CustomerDetailViewsVm GetCustomerDetail(int customerId);

        CustomerForDashboardVm GetCustomerDashboard(int customerId);

        CustomerForSummaryVm GetLastAddedCustomer();

        void AddNewCustomer(CustomerForCreationVm customer);

        void DeleteCustomer(int customerId);

        void AddNewContactDetail(ContactInfoForCreationVm contactDetail, int customerId);

        void ChangeContactDetails(ContactInfoForCreationVm contactDetail, int customerId);

        void RemoveContactDetail(int contactDetailId, int customerId);

        void AddNewAddress(AddressForCreationVm address, int customerId);

        AddressForCreationVm GetAddressToEdit(int addressId, int customerId);

        void ChangeCustomerAddress(AddressForCreationVm address, int customerId);

        void DeleteAddress(int address, int customerId);

        
    }
}
