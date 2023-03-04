using CafeMVC.Application.ViewModels.Customer;

namespace CafeMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        CustomerForSummaryVm AddNewCustomer(CustomerForCreationVm customer);

        void DeleteCustomer(int customerId);

        ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString);

        CustomerDetailViewsVm GetCustomerDetail(int customerId);

        CustomerForSummaryVm GetLastAddedCustomer(int id);
        
        int GeUsertCustomerId(string id);
    }
}
