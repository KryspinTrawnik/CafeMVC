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

        public IActionResult Index()
        {
            var listOfCustomers = _customerService.GetAllCustomers();
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
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCustomer(CustomerForCreationVm customer)
        {
            _customerService.AddNewCustomer(customer);
            return View();
        }

        [HttpGet]
        public IActionResult ViewCustomer(int customerId)
        {
            var customerToView = _customerService.GetCustomerDetail(customerId);
            return View();
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
            return View();
        }

        [HttpPost]
        public IActionResult AddNewContactDetail(ContactDetailForViewVm contactDetail, int customerId)
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
        public IActionResult ChangeContactDetail(int contactDetailId, int customerId)
        {
            _customerService.ChangeContactDetails(contactDetailId, customerId);
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
        public IActionResult ChangeAddress()
        {
            return View();
        }
        [HttpPatch]
        public IActionResult ChangeAddress(int addressId, int customerId)
        {
            _customerService.ChangeAddress(addressId, customerId);
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
