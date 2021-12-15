using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
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
            if(!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty; 
            }
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
            _customerService.AddNewCustomer(customer);
            
            return View(_customerService.GetLastAddedCustomer());
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int customerId)
        {
           _customerService.DeleteCustomer(customerId);
            return View();
        }
        ///****Contact Detail****\\\\\\
        [HttpGet]
        public IActionResult AddNewContactDetail(int customerId)
        {
            var newContactDetail = new ContactInfoForCreationVm()
            {
                CustomerId = customerId,
                AllContactDetailsTypes = _customerService.GetAllContactDetailTypes()
            };
            return View(newContactDetail );
        }

        [HttpPost]
        public IActionResult AddNewContactDetail(ContactInfoForCreationVm contactDetail)
        {
            _customerService.AddNewContactDetail(contactDetail);
            return RedirectToAction("CustomerView", "Customer", new { customerId = contactDetail.CustomerId}); 
        }

        [HttpGet]
        public IActionResult ChangeContactDetail(int contactDetailId)
        {
            var contactDetailForEdition =_customerService.GetContactDetailForEdition(contactDetailId);
            return View(contactDetailForEdition);
        }

        [HttpPost]
        public IActionResult ChangeContactDetail(ContactInfoForCreationVm contactDetail)
        {
            _customerService.ChangeContactDetails(contactDetail);
            return RedirectToAction("CustomerView", "Customer", new { customerId = contactDetail.CustomerId });

        }

        
        public IActionResult RemoveContactDetail(int contactDetailId)
        {
            int customerId = _customerService.GetContactDetailForEdition(contactDetailId).CustomerId;
            _customerService.RemoveContactDetail(contactDetailId);
            return RedirectToAction("CustomerView", "Customer", new { customerId = customerId });
        }
        ////**** Address ****\\\\
        

        [HttpGet]
        public IActionResult AddNewAddress(int customerId)
        {
            AddressForCreationVm addressForCreation = new()
            {
                CustomerId = customerId,
                AllAddressTypes = _customerService.GetAllAddressTypes()

            };
            return View(addressForCreation);
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddressForCreationVm address)
        {
            _customerService.AddNewAddress(address);
            return RedirectToAction("CustomerView", "Customer", new { customerId = address.CustomerId });

        }
        [HttpGet]
        public IActionResult ChangeAddress(int addressId)
        {
            AddressForCreationVm addressToBeEdited = _customerService.GetAddressToEdit(addressId);
            return View(addressToBeEdited);
        }
        [HttpPost]
        public IActionResult ChangeAddress(AddressForCreationVm editedAddress)
        {
            _customerService.ChangeCustomerAddress(editedAddress);
            return RedirectToAction("CustomerView", "Customer", new { customerId = editedAddress.CustomerId });
        }
        
        public IActionResult DeleteAddress(int addressId)
        {
            int customerId = _customerService.GetAddressToEdit(addressId).CustomerId;
            _customerService.DeleteAddress(addressId);
            return RedirectToAction("CustomerView", "Customer", new { customerId = customerId });
        }
        [HttpGet]
        public IActionResult ViewAddress(int addressId)
        {
            AddressForCreationVm address = _customerService.GetAddressToEdit(addressId);
            return View(address);
        }

    }
}
