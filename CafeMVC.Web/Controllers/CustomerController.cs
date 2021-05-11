using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var listOfCustomers = customerService.GetAllCustomers();
            return View(listOfCustomers);
        }

        [HttpGet]
        public IActionResult ViewUserDetails(int customerId)
        {
            var customerForView = customerServiece.GetCustomerById(customerId);
            return View(customerForView);
        }

        [HttpGet]
        public IActionResult AddNewCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCustomer(CustomerModel CustomerModel)
        {
            customerService.AddNewCustomer(CustomerModel);
            return View();
        }

        [HttpGet]
        public IActionResult ViewCustomer(int customerId)
        {
            var customerToView = customerService.GetCustomerById(customerId);
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
           customerService.Delete(customerId);
            return View();
        }

        [HttpGet]
        public IActionResult AddNewContactDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewContactDetail(ContactDetailForVM contactDetail, int customerId)
        {
            customerService.AddNewContactDetail(contactDetail, customerId);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeContactDetail()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult ChangeContactDetail(ContactDetailForVM contactDetail, int customerId)
        {
            customerService.ChangeContactDetails(contactDetail, customerId);
            return View();
        }

        [HttpGet]
        public IActionResult RemoveContactDetail()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult RemoveContactDetail(ContactDetailForVM contactDetail, int customerId)
        {
            customerService.RemoveContactDetail(contactDetail, customerId);
            return View();
        }
        [HttpGet]
        public IActionResult AddNewAddress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddressForVM address, int customerId)
        {
            customerService.AddNewAddress(address, customerId);
            return View();
        }
        [HttpGet]
        public IActionResult ChangeAddress()
        {
            return View();
        }
        [HttpPatch]
        public IActionResult ChangeAddress(AddressModel address, int customerId)
        {
            customerService.ChangeUserAddress(address);
            return View();
        }
        [HttpGet]
        public IActionResult DeleteAddress()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteAddress(AddressModel address, int customerId)
        {
            customerService.RemoveAddress(address, customerId);
            return View();
        }
        [HttpGet]
        public IActionResult ViewAddress()
        {
            return View();
        }

    }
}
