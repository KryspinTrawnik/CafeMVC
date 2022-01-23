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
            _customerRepository = customerRepository ?? throw new ArgumentNullException(); // nie musisz tego robić, ale ładnie wyglada ;)
            _mapper = mapper ?? throw new ArgumentNullException();                         // bodaj od C# 11 wchodzi ficzer "!" w argumentach, robi to co napisalem wyzej
        }

        // zamiast pisac bezsensowne komentarze - rozdziel to na mniejsze serwisy

        public int AddNewCustomer(CustomerForCreationVm customerVm)
        {
            CustomerForCreationVm newCustomer = SetInitialContactsAndAddressesTypes(customerVm);
            Customer customer = _mapper.Map<Customer>(newCustomer);

            return _customerRepository.AddNewCustomer(customer);
        }

        // one liner, kwestia preferencji. Ja wole tak
        public void DeleteCustomer(int customerId) =>_customerRepository.DeleteCustomer(customerId);

        public ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString)
        {
            // co jak `customersForLists` zworci ci 1mln rekordów? Skip i Take zrób na iqueryable który zwraca ci metoda `GetAllCustomser`
            List<CustomerForListVm> customersForLists = _customerRepository
                // GetAllCustomers = ta nazwa metody sugeruje, jakbym już miał dostać gotową listę a dostaje niezmaterializowany
                // IQueryable. Moja propozycja, to tak nie robić i zwracać view modele, spaginowane metody już z repozytorium.
                // wtedy ta metoda GetCustomersForPages byłaby de facto nie potrzebna, bo dostawałbyś dobry wynik z repo ;)
                .GetAllCustomers()
                .Where(x => x.FirstName.StartsWith(searchString) || x.Surname.StartsWith(searchString))
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider)
                // sprawdzasz gdzies parametry? Czy pageNo, pageSize nie jest liczbami ujemnymi?
                .Skip(pageSize * (pageNo - 1))
                .Take(pageSize)
                .ToList();

            return new()
            {
                ListOfAllCustomers = customersForLists,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = customersForLists.Count
            };
        }

        public CustomerForSummaryVm GetLastAddedCustomer(int id)
        {
            // fajnie, ze masz konsekwencje uzywania odpowiednich typow a nie `var`. Ja np uzywam var gdzie tylko sie da bo jest szybciej,
            // ale spoko, ze trzymasz sie jednej konwencji i nie uzywasz "var"
            Customer theLastCustomer = _customerRepository.GetCustomerById(id);
            
            return _mapper.Map<CustomerForSummaryVm>(theLastCustomer);
        }
        public CustomerDetailViewsVm GetCustomerDetail(int customerId)
        {
            Customer customer = _customerRepository.GetCustomerById(customerId);
            
            return _mapper.Map<CustomerDetailViewsVm>(customer);
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

        // uzywasz funkcji tylko tu, to po co ma byc ona publiczna?
        private CustomerForCreationVm SetInitialContactsAndAddressesTypes(CustomerForCreationVm createdCustomer)
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

        public void RemoveContactDetail(int contactDetailId) => _customerRepository.DeleteContactDetail(contactDetailId);

        public List<ContactDetailTypeForViewVm> GetAllContactDetailTypes()
            =>_customerRepository.GetAllContactDetailTypes()
                .ProjectTo<ContactDetailTypeForViewVm>(_mapper.ConfigurationProvider).ToList();

        public ContactInfoForCreationVm GetContactDetailForEdition(int contactDetailId)
        {
            ContactDetail contactDetail = _customerRepository.GetContactDetailById(contactDetailId);
            
            return _mapper.Map<ContactInfoForCreationVm>(contactDetail);
        }

        private List<AddressTypeVm> GetAllAddressTypes()
            =>_customerRepository.GetAllAddressTypes()
                .ProjectTo<AddressTypeVm>(_mapper.ConfigurationProvider).ToList();
    }
}
