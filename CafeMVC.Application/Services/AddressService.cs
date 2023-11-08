using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            addressForEdition.AllAddressTypes = GetAllAddressTypesSync();

            return addressForEdition;
        }

        public CustomerForCreationVm SetInitialContactsAndAddressesTypes(CustomerForCreationVm createdCustomer)
        {
            List<AddressType> allAddressTypes = _customerRepository.GetAllAddressTypesSync().ToList();
            List<ContactDetailType> allContactDetails = _customerRepository.GetAllContactDetailTypes().ToList();
            for (int i = 0; i < 2; i++)
            {
                if (createdCustomer.Addresses != null && createdCustomer.Addresses.Count > i)
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
        public async Task<List<AddressTypeVm>> GetAllAddressTypes()
        {
            var allTypes = await _customerRepository.GetAllAddressTypes();
            var allTypesVm = _mapper.Map<List<AddressTypeVm>>(allTypes);

            return allTypesVm;

        }


        public async Task<List<AddressForSummaryVm>> GetAllAddressesByCustomerId(int customerId)
        {
            List<Address> customersAddresses = await _customerRepository.GetAllCustomersAddresses(customerId);
            List<AddressForSummaryVm> addressesToSend = _mapper.Map<List<AddressForSummaryVm>>(customersAddresses);

            return addressesToSend;
        }

        public Address PrepareAddressToSave(AddressForCreationVm address)
        {
            Address addressToSave = _mapper.Map<Address>(address);

            return addressToSave;
        }

        public List<AddressTypeVm> GetAllAddressTypesSync()
        {
            return _customerRepository.GetAllAddressTypesSync()
                .ProjectTo<AddressTypeVm>(_mapper.ConfigurationProvider).ToList();

        }

        public AddressForOrderViewVm GetAddressToview(int id)
        {
            return _mapper.Map<AddressForOrderViewVm>(_customerRepository.GetAddressById(id));
        }

        public List<AddressForOrderViewVm> GetCustmersDeliveryAddresses(int id)
        {
             List <Address> addreses = _customerRepository.GetAllCustomersAddresses(id)
            .Result.Where(x => x.AddressTypeId == 2).ToList();
            List<AddressForOrderViewVm> addressesToSend = _mapper.Map<List<AddressForOrderViewVm>>(addreses);

            return addressesToSend;
        }

        public List<AddressForCreationVm> GetAllAddressesForCreationByCustomerId(int customerId) => _customerRepository.GetAllCustomersAddresses(customerId)
            .Result.AsQueryable().ProjectTo<AddressForCreationVm>(_mapper.ConfigurationProvider).ToList();
    }
}

