using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public void AddNewAddress(AddressForCreationVm address, int customerId)
        {
            Address newAddress = _mapper.Map<Address>(address);
            _customerRepository.AddNewAddress(newAddress);
        }

        public void AddNewContactDetail(ContactInfoForCreationVm contactDetail, int customerId)
        {
            ContactDetail customerContactInformation = _mapper.Map<ContactDetail>(contactDetail);
            _customerRepository.AddNewCustomerContactInfo(customerContactInformation);
        }

        public void AddNewCustomer(CustomerForCreationVm customerVm)
        {
            var newCustomer = SetInitialContactsAndAddressesTypes(customerVm);
            Customer customer = _mapper.Map<Customer>(newCustomer);
            _customerRepository.AddNewCustomer(customer);
        }

        public void ChangeCustomerAddress(AddressForCreationVm address)
        {
            Address updatedAddress = _mapper.Map<Address>(address);
            _customerRepository.UpdateAddress(updatedAddress);
        }

        public void ChangeContactDetails(ContactInfoForCreationVm contactDetail)
        {
            ContactDetail contactDetailEdited = _mapper.Map<ContactDetail>(contactDetail);
            _customerRepository.UpdateContactDetail(contactDetailEdited);
        }

        public void DeleteAddress(int addressId)
        {
            _customerRepository.DeleteAddress(addressId);
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
        }

        public ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString)
        {
            List<CustomerForListVm> customersForLists = _customerRepository.GetAllCustomers()
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            var customersToShow = customersForLists.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListOfCustomers listOfCustomers = new()
            {
                ListOfAllCustomers = customersToShow,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = customersForLists.Count
            };

            return listOfCustomers;
        }

        public CustomerForDashboardVm GetCustomerDashboard(int customerId)
        {
            Customer customer = _customerRepository.GetCustomerById(customerId);
            CustomerForDashboardVm customerForDashboard = _mapper.Map<CustomerForDashboardVm>(customer);
            return customerForDashboard;
        }

        public CustomerDetailViewsVm GetCustomerDetail(int customerId)
        {
            Customer customer = _customerRepository.GetCustomerById(customerId);
            CustomerDetailViewsVm customerDetailView = _mapper.Map<CustomerDetailViewsVm>(customer);
            return customerDetailView;
        }

        public void RemoveContactDetail(int contactDetailId)
        {
            _customerRepository.DeleteContactDetail(contactDetailId);
        }

        public AddressForCreationVm GetAddressToEdit(int addressId, int customerId)
        {
            Address address = _customerRepository.GetCustomerAddressById( addressId);
            AddressForCreationVm addressForEdition = _mapper.Map<AddressForCreationVm>(address);
            return addressForEdition;
 
        }

        public CustomerForSummaryVm GetLastAddedCustomer()
        {
            Customer theLastCustomer = _customerRepository.GetAllCustomers().ToList().Last();
            CustomerForSummaryVm customerForSummary = _mapper.Map<CustomerForSummaryVm>(theLastCustomer);

            return customerForSummary;
        }

        public CustomerForCreationVm SetInitialContactsAndAddressesTypes(CustomerForCreationVm createdCustomer)
        {
            List<AddressType> allAddressTypes = _customerRepository.GetAllAddressTypes().ToList();
            List<ContactDetailType> allContactDetails = _customerRepository.GetAllContactDetailTypes().ToList();
            for (int i = 0; i < 2; i++)
            {
                createdCustomer.Addresses[i].AddressTypeId = allAddressTypes[i].Id;
                createdCustomer.ContactDetails[i].ContactDetailTypeId = allContactDetails[i].Id;
            }
            return createdCustomer;
        }
    }
}
