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
        private readonly IAddressService _addressService;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IAddressService addressService)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
            _addressService = addressService ?? throw new ArgumentNullException();
        }

        public CustomerForSummaryVm AddNewCustomer(CustomerForCreationVm customerVm)
        {
            CustomerForCreationVm newCustomer = _addressService.SetInitialContactsAndAddressesTypes(customerVm);
            Customer customer = _mapper.Map<Customer>(newCustomer);

            return GetLastAddedCustomer(_customerRepository.AddNewCustomer(customer));
        }

        public void DeleteCustomer(int customerId) => _customerRepository.DeleteCustomer(customerId);

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

    }
}
