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
            _customerRepository.AddNewAddress(newAddress, customerId);
        }

        public void AddNewContactDetail(ContactInfoForCreationVm contactDetail, int customerId)
        {
            ContactDetail customerContactInformation = _mapper.Map<ContactDetail>(contactDetail);
            _customerRepository.AddNewCustomerContactInfo(customerContactInformation, customerId);
        }

        public void AddNewCustomer(CustomerForCreationVm customer)
        {
            Customer newCustomer = _mapper.Map<Customer>(customer);
            _customerRepository.AddItem(newCustomer);
        }

        public void ChangeCustomerAddress(AddressForCreationVm address, int customerId)
        {
            Customer customer = _customerRepository.GetItemById(customerId);
            Address addressToReplace = customer.Addresses.FirstOrDefault(x => x.Id == address.Id);
            customer.Addresses.Remove(addressToReplace);
            Address updatedAddress = _mapper.Map<Address>(address);
            customer.Addresses.Add(updatedAddress);
            _customerRepository.UpdateItem(customer);
        }

        public void ChangeContactDetails(ContactInfoForCreationVm contactDetail, int customerId)
        {
            Customer customer = _customerRepository.GetItemById(customerId);
            ContactDetail customerContactForChange = customer.ContactDetails.FirstOrDefault(x => x.Id == contactDetail.Id);
            customer.ContactDetails.Remove(customerContactForChange);
            ContactDetail customerContactEdited = _mapper.Map<ContactDetail>(contactDetail);
            customer.ContactDetails.Add(customerContactEdited);
            _customerRepository.UpdateItem(customer);
        }

        public void DeleteAddress(int addressId, int customerId)
        {
            Customer customer = _customerRepository.GetItemById(customerId);
            Address addressToBeRemoved = customer.Addresses.FirstOrDefault(x => x.Id == addressId);
            customer.Addresses.Remove(addressToBeRemoved);
            _customerRepository.UpdateItem(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteItem(customerId);
        }

        public ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString)
        {
            List<CustomerForListVm> customersForLists = _customerRepository.GetAllType()
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
            Customer customer = _customerRepository.GetItemById(customerId);
            CustomerForDashboardVm customerForDashboard = _mapper.Map<CustomerForDashboardVm>(customer);
            return customerForDashboard;
        }

        public CustomerDetailViewsVm GetCustomerDetail(int customerId)
        {
            Customer customer = _customerRepository.GetItemById(customerId);
            CustomerDetailViewsVm customerDetailView = _mapper.Map<CustomerDetailViewsVm>(customer);
            return customerDetailView;
        }

        public void RemoveContactDetail(int contactDetailId, int customerId)
        {
            Customer customer = _customerRepository.GetItemById(customerId);
            ContactDetail customerContactToBeRemoved = customer.ContactDetails
                .FirstOrDefault(x => x.ContactDetailTypeId == contactDetailId);
            customer.ContactDetails.Remove(customerContactToBeRemoved);
            _customerRepository.UpdateItem(customer);
        }

        public AddressForCreationVm GetAddressToEdit(int addressId, int customerId)
        {
            Address address = _customerRepository.GetCustomerAddressById(customerId, addressId);
            AddressForCreationVm addressForEdition = _mapper.Map<AddressForCreationVm>(address);
            return addressForEdition;
 
        }

        public CustomerForSummaryVm GetLastAddedCustomer()
        {
            Customer theLastCustomer = _customerRepository.GetAllType().ToList().Last();
            CustomerForSummaryVm customerForSummary = _mapper.Map<CustomerForSummaryVm>(theLastCustomer);

            return customerForSummary;
        }

        public CustomerForCreationVm SetInitialContactsAndAddressesTypes(CustomerForCreationVm createdCustomer)
        {
            List<AddressType> allAddressTypes = _customerRepository.GetAllAddressTypes().ToList();
            List<ContactDetailType> allContactDetails = _customerRepository.GetAllContactDetailTypes().ToList();
            for(int i =0; i < 2; i++)
            {
                createdCustomer.Addresses[i].AddressType = new AddressTypeVm{ Name = allAddressTypes[i].Name };
                createdCustomer.ContactDetails[i].ContactDetailType = new ContactDetailTypeForCreationVm
                {
                    Name = allContactDetails[i].Name
                };
            }
            return createdCustomer;
        }
    }
}
