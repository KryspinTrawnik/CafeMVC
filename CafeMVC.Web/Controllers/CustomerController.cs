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

       
        [HttpGet]
        public IActionResult ViewCustomer(int customerId)
        {
            var customerToView = _customerService.GetCustomerDetail(customerId);
            return View(customerToView);
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
            return RedirectToAction("ViewCustomer"); 
        }

        [HttpGet]
        public IActionResult ChangeContactDetail()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult ChangeContactDetail(ContactInfoForCreationVm contactDetail)
        {
            _customerService.ChangeContactDetails(contactDetail);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveContactDetail(int contactDetailId)
        {
            _customerService.RemoveContactDetail(contactDetailId);
            return View();
        }
        ////**** Address ****\\\\
        

        [HttpGet]
        public IActionResult AddNewAddress()
        {
            return View(new AddressForCreationVm());
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddressForCreationVm address, int customerId)
        {
            _customerService.AddNewAddress(address, customerId);
            return View();
        }
        [HttpGet]
        public IActionResult ChangeAddress(int addressId)
        {
            AddressForEdtitionVm addressToBeEdited = _customerService.GetAddressToEdit(addressId);
            return View(addressToBeEdited);
        }
        [HttpPost]
        public IActionResult ChangeAddress(AddressForCreationVm editedAddress)
        {
            _customerService.ChangeCustomerAddress(editedAddress);
            return View();
        }
        
        [HttpDelete]
        public IActionResult DeleteAddress(int addressId)
        {
            _customerService.DeleteAddress(addressId);
            return View();
        }
        [HttpGet]
        public IActionResult ViewAddress(int addressId)
        {
            var address = _customerService.GetAddressToEdit(addressId);
            return View();
        }

    }
}
