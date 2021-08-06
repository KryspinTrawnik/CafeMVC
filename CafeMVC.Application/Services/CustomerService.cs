using AutoMapper;
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

        public void DeleteAddress(int address, int customerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerForListVm> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerForDashboardVm GetCustomerDashboard(int customerId)
        {
            throw new NotImplementedException();
        }

        public CustomerDetailsVm GetCustomerDetail(int customerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveContactDetail(int contactDetailId, int customerId)
        {
            throw new NotImplementedException();
        }

        public AddressForCreationVm GetAddressToEdit(int customerId, int addressId)
        {
            Address address = _customerRepository.GetCustomerAddressById(customerId, addressId);
            AddressForCreationVm addressForEdition = _mapper.Map<AddressForCreationVm>(address);
            return addressForEdition;
 
        }
    }
}
