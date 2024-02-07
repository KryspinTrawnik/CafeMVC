using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using System.Collections.Generic;

namespace CafeMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        CustomerForSummaryVm AddNewCustomer(CustomerForCreationVm customer);

        void DeleteCustomer(int customerId);

        ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString);

        CustomerDetailViewsVm GetCustomerDetail(int customerId);

        CustomerForSummaryVm GetLastAddedCustomer(int id);

        List<CreditCardForUserListVm> GetAllCustomersCard(int customerId);
        string GetCustomerSurnameName(int customerId);
        string GetCustomerFirstName(int customerId);
    }
}
