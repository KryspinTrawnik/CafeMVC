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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
             
                        //////////Customer Actions/////
        
        public void AddNewCustomer(CustomerForCreationVm customerVm)
        {
            CustomerForCreationVm newCustomer = SetInitialContactsAndAddressesTypes(customerVm);
            Customer customer = _mapper.Map<Customer>(newCustomer);
            _customerRepository.AddNewCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
        }

        public ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString)
        {
            List<CustomerForListVm> customersForLists = _customerRepository.GetAllCustomers()
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            List<CustomerForListVm> customersToShow = customersForLists.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
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

        public CustomerForSummaryVm GetLastAddedCustomer()
        {
            Customer theLastCustomer = _customerRepository.GetAllCustomers().ToList().Last();
            CustomerForSummaryVm customerForSummary = _mapper.Map<CustomerForSummaryVm>(theLastCustomer);

            return customerForSummary;
        }
        public CustomerDetailViewsVm GetCustomerDetail(int customerId)
        {
            Customer customer = _customerRepository.GetCustomerById(customerId);
            CustomerDetailViewsVm customerDetailView = _mapper.Map<CustomerDetailViewsVm>(customer);
            return customerDetailView;
        }
                    //////Address Actions/////////
                    
        public void AddNewAddress(AddressForCreationVm address)
        {
            Address newAddress = _mapper.Map<Address>(address);
            _customerRepository.AddNewAddress(newAddress);
        }

        public void DeleteAddress(int addressId)
        {
            _customerRepository.DeleteAddress(addressId);
        }

        public AddressForEdtitionVm GetAddressToEdit(int addressId)
        {
            Address address = _customerRepository.GetAddressById(addressId);
            AddressForEdtitionVm addressForEdition = _mapper.Map<AddressForEdtitionVm>(address);
            return addressForEdition;

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

        public void ChangeCustomerAddress(AddressForCreationVm address)
        {
            Address updatedAddress = _mapper.Map<Address>(address);
            _customerRepository.UpdateAddress(updatedAddress);
        }


                    //////ContactDetails actions//////
                    
        public void AddNewContactDetail(ContactInfoForCreationVm contactDetail)
        {
            ContactDetail customerContactInformation = _mapper.Map<ContactDetail>(contactDetail);
            _customerRepository.AddNewContactDetail(customerContactInformation);
        }

        public void ChangeContactDetails(ContactInfoForCreationVm contactDetail)
        {
            ContactDetail contactDetailEdited = _mapper.Map<ContactDetail>(contactDetail);
            _customerRepository.UpdateContactDetail(contactDetailEdited);
        }

        public void RemoveContactDetail(int contactDetailId)
        {
            _customerRepository.DeleteContactDetail(contactDetailId);
        }


        public List<ContactDetailTypeForViewVm> GetAllContactDetailTypes()
        {
            List<ContactDetailTypeForViewVm> allContactTypes = _customerRepository.GetAllContactDetailTypes()
                .ProjectTo<ContactDetailTypeForViewVm>(_mapper.ConfigurationProvider).ToList();

            return allContactTypes;
        }

        public ContactInfoForCreationVm GetContactDetailForEdition(int contactDetailId)
        {
            ContactDetail contactDetail = _customerRepository.GetContactDetailById(contactDetailId);
            ContactInfoForCreationVm contactDetailForEdition = _mapper.Map<ContactInfoForCreationVm>(contactDetail);
            return contactDetailForEdition;
        }

        public List<AddressTypeVm> GetAllAddressTypes()
        {
            List < AddressTypeVm > allAddressType = _customerRepository.GetAllAddressTypes()
                .ProjectTo<AddressTypeVm>(_mapper.ConfigurationProvider).ToList();
            return allAddressType;
        }
    }
}
