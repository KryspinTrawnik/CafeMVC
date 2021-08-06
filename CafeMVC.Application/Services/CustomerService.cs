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
            CustomerContactInformation customerContactInformation = _mapper.Map<CustomerContactInformation>(contactDetail);
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

        public void ChangeContactDetails(int contactDetailId, int customerId)
        {
            throw new NotImplementedException();
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

        public List<CustomerForListVm> GetAllCustomers()
        {
            List<CustomerForListVm> customerForLists = _customerRepository.GetAllType()
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();

            return customerForLists;
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
            CustomerContactInformation customerContactToBeRemoved = customer.UserContactInformations
                .FirstOrDefault(x => x.ContactDetailTypId == contactDetailId);
            customer.UserContactInformations.Remove(customerContactToBeRemoved);
            _customerRepository.UpdateItem(customer);
        }

        public AddressForCreationVm GetAddressToEdit(int customerId, int addressId)
        {
            Address address = _customerRepository.GetCustomerAddressById(customerId, addressId);
            AddressForCreationVm addressForEdition = _mapper.Map<AddressForCreationVm>(address);
            return addressForEdition;
 
        }
    }
}
