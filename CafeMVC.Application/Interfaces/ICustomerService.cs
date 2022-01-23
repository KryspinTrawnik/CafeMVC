using CafeMVC.Application.ViewModels.Customer;
using System.Collections.Generic;

namespace CafeMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        int AddNewCustomer(CustomerForCreationVm customer);

        void DeleteCustomer(int customerId);

        ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString);

        CustomerDetailViewsVm GetCustomerDetail(int customerId);

        CustomerForSummaryVm GetLastAddedCustomer(int id);

        void AddNewAddress(AddressForCreationVm address);

        AddressForCreationVm GetAddressToEdit(int addressId);

        void ChangeCustomerAddress(AddressForCreationVm address);

        void DeleteAddress(int addressId);

        void AddNewContactDetail(ContactInfoForCreationVm contactDetail);

        void ChangeContactDetails(ContactInfoForCreationVm contactDetail);

        void RemoveContactDetail(int contactDetailId);

        List<ContactDetailTypeForViewVm> GetAllContactDetailTypes();
        ContactInfoForCreationVm GetContactDetailForEdition(int contactDetailId);
    }

}
