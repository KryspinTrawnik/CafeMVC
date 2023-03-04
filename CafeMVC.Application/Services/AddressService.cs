using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public AddressService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        
        public void AddNewAddress(AddressForCreationVm address) => _customerRepository.AddNewAddress(_mapper.Map<Address>(address));

        public void DeleteAddress(int addressId) => _customerRepository.DeleteAddress(addressId);
        

        public AddressForCreationVm GetAddressToEdit(int addressId)
        {
            Address address = _customerRepository.GetAddressById(addressId);
            AddressForCreationVm addressForEdition = _mapper.Map<AddressForCreationVm>(address);
            addressForEdition.AllAddressTypes = GetAllAddressTypes();
            
            return addressForEdition;
        }

        public CustomerForCreationVm SetInitialContactsAndAddressesTypes(CustomerForCreationVm createdCustomer)
        {
            List<AddressType> allAddressTypes = _customerRepository.GetAllAddressTypes().ToList();
            List<ContactDetailType> allContactDetails = _customerRepository.GetAllContactDetailTypes().ToList();
            for (int i = 0; i < 2; i++)
            {
                if(createdCustomer.Addresses != null && createdCustomer.Addresses.Count > i)
                {
                createdCustomer.Addresses[i].AddressTypeId = allAddressTypes[i].Id;
                }
                createdCustomer.ContactDetails[i].ContactDetailTypeId = allContactDetails[i].Id;
            }
            
            return createdCustomer;
        }

        public void ChangeCustomerAddress(AddressForCreationVm address)
        {
            Address updatedAddress = _mapper.Map<Address>(address);
            _customerRepository.UpdateAddress(updatedAddress);
        }
        public List<AddressTypeVm> GetAllAddressTypes()
        {
            List<AddressTypeVm> allAddressType = _customerRepository.GetAllAddressTypes()
                .ProjectTo<AddressTypeVm>(_mapper.ConfigurationProvider).ToList();
            
            return allAddressType;
        }
    }
}
