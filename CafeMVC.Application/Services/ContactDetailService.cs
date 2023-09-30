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
    public class ContactDetailService : IContactDetailService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public ContactDetailService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
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

        public CustomerContactDetails GetCustomerContactDetails(int customerId)
        {
            List<CustomerContactInfoForViewVm> allCustomerContactDetails = _customerRepository.GetAllCustomerContactDetails(customerId)
                .ProjectTo<CustomerContactInfoForViewVm>(_mapper.ConfigurationProvider).ToList();
            CustomerContactDetails customerContactDetails = new CustomerContactDetails();

            if (allCustomerContactDetails.Where(x => x.ContactDetailTypeId == 1).ToList() != null)
            {
                customerContactDetails.Emails = allCustomerContactDetails.Where(x => x.ContactDetailTypeId == 1).ToList();
            }
            if (allCustomerContactDetails.Where(x => x.ContactDetailTypeId == 1).ToList() != null)
            {
                customerContactDetails.PhoneNumbers = allCustomerContactDetails.Where(x => x.ContactDetailTypeId == 2).ToList();
            }

            customerContactDetails.CustomerId = customerId;

            return customerContactDetails;
        }
    }
}

