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

        CustomerDetailsVm GetCustomerById(int customerId);

        void AddNewCustomer(CustomerForCreationVm customer);

        void DeleteCustomer(int customerId);
    }
}
