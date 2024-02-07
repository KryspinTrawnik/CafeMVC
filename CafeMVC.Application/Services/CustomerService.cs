using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
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
        private readonly IAddressService _addressService;
        private readonly IContactDetailService _contactDetailService;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IAddressService addressService, IContactDetailService contactDetailService)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _addressService = addressService;
            _contactDetailService = contactDetailService;
        }
        private List<PaymentCard> GetValidCards(List<PaymentCard> listOfCreditCards)
        {
            int thisYear = DateTime.Now.Year;
            int thisMonth = DateTime.Now.Month;

            for (int i = 0; i < listOfCreditCards.Count; i++)
            {
                string expiryDate = listOfCreditCards[i].ExpirationDate;
                int year = int.Parse("20"+expiryDate.Substring(3));
                int month = int.Parse(expiryDate.Substring(0, 2));
                if(year < thisYear || year == thisYear && thisMonth > month)
                {
                    listOfCreditCards.Remove(listOfCreditCards[i]);
                }

            }

            return listOfCreditCards;
        }

        public CustomerForSummaryVm AddNewCustomer(CustomerForCreationVm customerVm)
        {

            CustomerForCreationVm newCustomer = _addressService.SetInitialContactsAndAddressesTypes(customerVm);
            Customer customer = _mapper.Map<Customer>(newCustomer);

            return GetLastAddedCustomer(_customerRepository.AddNewCustomer(customer));
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customerToDelete = _customerRepository.GetCustomerById(customerId);
            if (customerToDelete.ContactDetails != null)
            {
                foreach (ContactDetail contactDetail in customerToDelete.ContactDetails)
                {
                    _contactDetailService.RemoveContactDetail(contactDetail.Id);
                }
            }
            if (customerToDelete.Addresses != null)
            {
                foreach (Address address in customerToDelete.Addresses)
                {
                    _addressService.DeleteAddress(address.Id);
                }
            }
            _customerRepository.DeleteCustomer(customerId);
        }

        public ListOfCustomers GetCustomersForPages(int pageSize, int pageNo, string searchString)
        {
            List<CustomerForListVm> allCustomers = _customerRepository.GetAllCustomers().Where(x => x.FirstName.StartsWith(searchString) || x.Surname.StartsWith(searchString))
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            List<CustomerForListVm> customersToDisplay = allCustomers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            return new()
            {
                ListOfAllCustomers = customersToDisplay,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = allCustomers.Count
            };
        }

        public CustomerForSummaryVm GetLastAddedCustomer(int id)
        {
            Customer theLastCustomer = _customerRepository.GetCustomerById(id);

            return _mapper.Map<CustomerForSummaryVm>(theLastCustomer);
        }

        public CustomerDetailViewsVm GetCustomerDetail(int customerId)
        {
            Customer customer = _customerRepository.GetCustomerById(customerId);

            return _mapper.Map<CustomerDetailViewsVm>(customer);
        }

        public List<CreditCardForUserListVm> GetAllCustomersCard(int customerId)
        {
            List<PaymentCard> listOfCreditCards = _customerRepository.GetAllCustomersPaymentCards(customerId).ToList();
            if (listOfCreditCards.Count > 0)
            {
            List<CreditCardForUserListVm> listOfCreditCardsVm = _mapper.Map<List<CreditCardForUserListVm>>(GetValidCards(listOfCreditCards));

            return listOfCreditCardsVm;
            
            }

            return null;
        }

        public string GetCustomerSurnameName(int customerId) => _customerRepository.GetCustomerById(customerId).Surname;

        public string GetCustomerFirstName(int customerId) => _customerRepository.GetCustomerById(customerId).FirstName;
    }
}
