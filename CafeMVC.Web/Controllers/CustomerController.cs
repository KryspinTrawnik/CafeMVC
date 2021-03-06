using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CafeMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        private readonly IAddressService _addressService;

        private readonly IContactDetailService _contactDetailService;


        public CustomerController(ICustomerService customerService, IAddressService addressService, IContactDetailService contactDetailService)
        {
            _customerService = customerService;
            _addressService = addressService;
            _contactDetailService = contactDetailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listOfCustomers = _customerService.GetCustomersForPages(20, 1, "");
            return View(listOfCustomers);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            pageSize = 20;
            var listOfCustomers = _customerService.GetCustomersForPages(pageSize, pageNo.Value, searchString);

            return View(listOfCustomers);
        }

        [HttpGet]
        public IActionResult CustomerView(int customerId)
        {
            CustomerDetailViewsVm customerForView = _customerService.GetCustomerDetail(customerId);
            return View(customerForView);
        }

        [HttpGet]
        public IActionResult AddNewCustomer()
        {
            return View(new CustomerForCreationVm());
        }

        [HttpPost]
        public IActionResult AddNewCustomerSummary(CustomerForCreationVm customer)
        {
            if (customer.Btn == "Submit")
            {
                CustomerForSummaryVm customerForSummary = _customerService.AddNewCustomer(customer);
                return View(customerForSummary);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }

        public IActionResult DeleteCustomer(int customerId)
        {
            _customerService.DeleteCustomer(customerId);

            return RedirectToAction("index", "Home");
        }
        ///****Contact Detail****\\\\\\
        [HttpGet]
        public IActionResult AddNewContactDetail(int customerId)
        {
            var newContactDetail = new ContactInfoForCreationVm()
            {
                CustomerId = customerId,
                AllContactDetailsTypes = _contactDetailService.GetAllContactDetailTypes()
            };
            return View(newContactDetail);
        }

        [HttpPost]
        public IActionResult AddNewContactDetail(ContactInfoForCreationVm contactDetail)
        {
            if (contactDetail.Btn == "Submit")
            {
                _contactDetailService.AddNewContactDetail(contactDetail);
            }
            return RedirectToAction("CustomerView", "Customer", new { customerId = contactDetail.CustomerId });
        }

        [HttpGet]
        public IActionResult ChangeContactDetail(int contactDetailId)
        {
            var contactDetailForEdition = _contactDetailService.GetContactDetailForEdition(contactDetailId);
            return View(contactDetailForEdition);
        }

        [HttpPost]
        public IActionResult ChangeContactDetail(ContactInfoForCreationVm contactDetail)
        {
            if (contactDetail.Btn == "Submit")
            {
                _contactDetailService.ChangeContactDetails(contactDetail);
            }
            return RedirectToAction("CustomerView", "Customer", new { customerId = contactDetail.CustomerId });
        }

        public IActionResult RemoveContactDetail(int contactDetailId)
        {
            int customerId = _contactDetailService.GetContactDetailForEdition(contactDetailId).CustomerId;
            _contactDetailService.RemoveContactDetail(contactDetailId);
            return RedirectToAction("CustomerView", "Customer", new { customerId = customerId });
        }
        ////**** Address ****\\\\


        [HttpGet]
        public IActionResult AddNewAddress(int customerId)
        {
            AddressForCreationVm addressForCreation = new()
            {
                CustomerId = customerId,
                AllAddressTypes = _addressService.GetAllAddressTypes()

            };
            return View(addressForCreation);
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddressForCreationVm address)
        {
            if (address.Btn == "Submit")
            {
                _addressService.AddNewAddress(address);
            }
            return RedirectToAction("CustomerView", "Customer", new { customerId = address.CustomerId });

        }
        [HttpGet]
        public IActionResult ChangeAddress(int addressId)
        {
            AddressForCreationVm addressToBeEdited = _addressService.GetAddressToEdit(addressId);
            return View(addressToBeEdited);
        }
        [HttpPost]
        public IActionResult ChangeAddress(AddressForCreationVm editedAddress)
        {
            if (editedAddress.Btn == "Submit")
            {
                _addressService.ChangeCustomerAddress(editedAddress);
            }
            return RedirectToAction("CustomerView", "Customer", new { customerId = editedAddress.CustomerId });
        }

        public IActionResult DeleteAddress(int addressId)
        {
            int customerId = _addressService.GetAddressToEdit(addressId).CustomerId;
            _addressService.DeleteAddress(addressId);
            return RedirectToAction("CustomerView", "Customer", new { customerId = customerId });
        }
        [HttpGet]
        public IActionResult ViewAddress(int addressId)
        {
            AddressForCreationVm address = _addressService.GetAddressToEdit(addressId);
            return View(address);
        }

    }
}
