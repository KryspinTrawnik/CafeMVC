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
            var listOfCustomers = _customerService.GetCustomersForPages(2, 1, "");
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
        public IActionResult ViewUserDetails(int customerId)
        {
            var customerForView = _customerService.GetCustomerDetail(customerId);
            return View(customerForView);
        }

        [HttpGet]
        public IActionResult CustomerDashboard(int customerId)
        {
            var customerViewForDashboard = _customerService.GetCustomerDashboard(customerId);
            return View(customerViewForDashboard);
        }

        [HttpGet]
        public IActionResult AddNewCustomer()
        {
            return View(new CustomerForCreationVm());
        }

        [HttpPost]
        public IActionResult AddNewCustomer(CustomerForCreationVm customer)
        {
            _customerService.AddNewCustomer(customer);
            return RedirectToAction("AddAddressToNewCustomer");
        }

        [HttpGet]
        public IActionResult ViewCustomer(int customerId)
        {
            var customerToView = _customerService.GetCustomerDetail(customerId);
            return View(customerToView);
        }

        [HttpGet]
        public IActionResult DeleteCustomer()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int customerId)
        {
           _customerService.DeleteCustomer(customerId);
            return View();
        }

        [HttpGet]
        public IActionResult AddNewContactDetail()
        {
            return View(new ContactInfoForCreationVm() );
        }

        [HttpPost]
        public IActionResult AddNewContactDetail(ContactInfoForCreationVm contactDetail, int customerId)
        {
            _customerService.AddNewContactDetail(contactDetail, customerId);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeContactDetail()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult ChangeContactDetail(ContactInfoForCreationVm contactDetail, int customerId)
        {
            _customerService.ChangeContactDetails(contactDetail, customerId);
            return View();
        }

        [HttpGet]
        public IActionResult RemoveContactDetail()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult RemoveContactDetail(int contactDetailId, int customerId)
        {
            _customerService.RemoveContactDetail(contactDetailId, customerId);
            return View();
        }

        [HttpGet]
        public IActionResult AddAddressToNewCustomer(CustomerForCreationVm newCustomer)
        {
            return View(new AddressForCreationVm());
        }

        [HttpPost]
        public IActionResult AddAddressToNewCustomer(AddressForCreationVm address, int customerId)
        {
            _customerService.AddNewAddress(address, customerId);
            return View();
        }

        [HttpGet]
        public IActionResult AddNewAddress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddressForCreationVm address, int customerId)
        {
            _customerService.AddNewAddress(address, customerId);
            return View();
        }
        [HttpGet]
        public IActionResult ChangeAddress(int addressId, int customerId)
        {
            AddressForCreationVm addressToBeEdited = _customerService.GetAddressToEdit(addressId, customerId);
            return View(addressToBeEdited);
        }
        [HttpPost]
        public IActionResult ChangeAddress(AddressForCreationVm editedAddress, int customerId)
        {
            _customerService.ChangeCustomerAddress(editedAddress, customerId);
            return View();
        }
        [HttpGet]
        public IActionResult DeleteAddress()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteAddress(int addressId, int customerId)
        {
            _customerService.DeleteAddress(addressId, customerId);
            return View();
        }
        [HttpGet]
        public IActionResult ViewAddress()
        {
            return View();
        }

    }
}
