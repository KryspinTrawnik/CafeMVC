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
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = string.Empty;
                pageSize = 20;
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
            // wszelkie stringi do jakichs klas Consts.
            if (customer.Btn.Equals("Submit"))
            {
                // to powinno trafic do oddzielnej, jednej metody. Po co wywolywac serwis dwa razy?
                int idNewcustomer = _customerService.AddNewCustomer(customer);
                var lastcustomer = _customerService.GetLastAddedCustomer(idNewcustomer);

                return View(lastcustomer);
            }

            return RedirectToAction("index", "Home");
        }

        public IActionResult DeleteCustomer(int customerId)
        {
            _customerService.DeleteCustomer(customerId);

            return RedirectToAction("index", "Home");
        }

        // dodawanie powinno byc HttpPost.
        [HttpGet]
        public IActionResult AddNewContactDetail(int customerId)
        {
            // jakiś error handling? skad wiemy, ze taki customerId istnieje?
            var newContactDetail = new ContactInfoForCreationVm()
            {
                CustomerId = customerId,
                AllContactDetailsTypes = _customerService.GetAllContactDetailTypes()
            };

            return View(newContactDetail);
        }

        [HttpPost]
        public IActionResult AddNewContactDetail(ContactInfoForCreationVm contactDetail)
        {
            // tak jak wyzej. Teraz w pamięci masz dwa stringi "Submit". A za pomocą stałych miałbyś tylko jeden Submit w pamięci ;) Tak samo
            // wszelkie indexy i homy
            if (contactDetail.Btn == "Submit")
            {
                _customerService.AddNewContactDetail(contactDetail);
            }

            return RedirectToAction("CustomerView", "Customer", new { customerId = contactDetail.CustomerId });
        }

        // Post
        [HttpGet]
        public IActionResult ChangeContactDetail(int contactDetailId)
        {
            var contactDetailForEdition = _customerService.GetContactDetailForEdition(contactDetailId);
            return View(contactDetailForEdition);
        }

        // HttpPut
        [HttpPost]
        public IActionResult ChangeContactDetail(ContactInfoForCreationVm contactDetail)
        {
            if (contactDetail.Btn == "Submit")
            {
                _customerService.ChangeContactDetails(contactDetail);
            }
            return RedirectToAction("CustomerView", "Customer", new { customerId = contactDetail.CustomerId });
        }

        private IActionResult RemoveContactDetail(int contactDetailId)
        {
            int customerId = _customerService.GetContactDetailForEdition(contactDetailId).CustomerId;
            _customerService.RemoveContactDetail(contactDetailId);
            return RedirectToAction("CustomerView", "Customer", new { customerId = customerId });
        }

        // Post
        [HttpGet]
        public IActionResult AddNewAddress(int customerId)
        {
            AddressForCreationVm addressForCreation = new()
            {
                CustomerId = customerId,
                // tutaj fuckup, nie zauwazylem ze gdzies tego uzywasz
                AllAddressTypes = _customerService.GetAllAddressTypes()

            };
            return View(addressForCreation);
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddressForCreationVm address)
        {
            if (address.Btn == "Submit")
            {
                _customerService.AddNewAddress(address);
            }
            return RedirectToAction("CustomerView", "Customer", new { customerId = address.CustomerId });

        }
        // Post
        [HttpGet]
        public IActionResult ChangeAddress(int addressId)
        {
            AddressForCreationVm addressToBeEdited = _customerService.GetAddressToEdit(addressId);
            return View(addressToBeEdited);
        }
        [HttpPost]
        public IActionResult ChangeAddress(AddressForCreationVm editedAddress)
        {
            if (editedAddress.Btn == "Submit")
            {
                _customerService.ChangeCustomerAddress(editedAddress);
            }
            return RedirectToAction("CustomerView", "Customer", new { customerId = editedAddress.CustomerId });
        }

        private IActionResult DeleteAddress(int addressId)
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
