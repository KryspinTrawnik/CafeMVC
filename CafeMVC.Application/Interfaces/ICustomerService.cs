﻿using CafeMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ////////Customer actiona/////
        
        void AddNewCustomer(CustomerForCreationVm customer);

        void DeleteCustomer(int customerId);

        ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString);

        CustomerDetailViewsVm GetCustomerDetail(int customerId);

        CustomerForDashboardVm GetCustomerDashboard(int customerId);

        CustomerForSummaryVm GetLastAddedCustomer();
        
        /////Address actions////
        
        void AddNewAddress(AddressForCreationVm address, int customerId);

        AddressForEdtitionVm GetAddressToEdit(int addressId, int customerId);

        void ChangeCustomerAddress(AddressForCreationVm address);
     
        CustomerForCreationVm SetInitialContactsAndAddressesTypes( CustomerForCreationVm newCreatedCustomer);

        void DeleteAddress(int addressId);

        /////ContactDetails Actions///
        
        void AddNewContactDetail(ContactInfoForCreationVm contactDetail);

        void ChangeContactDetails(ContactInfoForCreationVm contactDetail);

        void RemoveContactDetail(int contactDetailId);

    }

}
