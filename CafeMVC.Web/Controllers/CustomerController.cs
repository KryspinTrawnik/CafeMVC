﻿using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CafeMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        private readonly IAddressService _addressService;

        private readonly IContactDetailService _contactDetailService;

        private readonly Microsoft.AspNetCore.Identity.UserManager<UserCustomerDetails> _userManager;


        public CustomerController(ICustomerService customerService, IAddressService addressService, IContactDetailService contactDetailService, Microsoft.AspNetCore.Identity.UserManager<UserCustomerDetails> userManager)
        {
            _customerService = customerService;
            _addressService = addressService;
            _contactDetailService = contactDetailService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var listOfCustomers = _customerService.GetCustomersForPages(20, 1, "");
            return View(listOfCustomers);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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

            return PartialView("CustomerViewPartial", customerForView);
        }
        [HttpGet]
        public IActionResult ContactDetailsPartial(int customerId)
        {
            CustomerContactDetails customerForView = _contactDetailService.GetCustomerContactDetails(customerId);

            return PartialView("ContactDetailsPartial", customerForView);
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewCustomer()
        {
            return View(new CustomerForCreationVm());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCustomer(int customerId)
        {
            _customerService.DeleteCustomer(customerId);

            return RedirectToAction("index", "Home");
        }
        public IActionResult GetCustomerId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                UserCustomerDetails currentUser = _userManager.FindByIdAsync(userId).Result;
                if (currentUser != null)
                {
                    int customerId = currentUser.CustomerId.Value;
                    return PartialView("GetCustomerId", customerId);
                }
            }

            return View("UserNotFound");
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
            return Redirect("/Identity/Account/Manage/ContactDetails");
        }

        [HttpGet]
        public IActionResult ChangeContactDetail(int contactDetailId)
        {
            var contactDetailForEdition = _contactDetailService.GetContactDetailForEdition(contactDetailId);
            contactDetailForEdition.AllContactDetailsTypes = _contactDetailService.GetAllContactDetailTypes();

            return View(contactDetailForEdition);
        }

        [HttpPost]
        public IActionResult ChangeContactDetail(ContactInfoForCreationVm contactDetail)
        {
            if (contactDetail.Btn == "Submit")
            {
                _contactDetailService.ChangeContactDetails(contactDetail);
            }
            return Redirect("/Identity/Account/Manage/ContactDetails");
        }

        public IActionResult RemoveContactDetail(int contactDetailId)
        {
            int customerId = _contactDetailService.GetContactDetailForEdition(contactDetailId).CustomerId.Value;
            _contactDetailService.RemoveContactDetail(contactDetailId);

            return Redirect("/Identity/Account/Manage/ContactDetails");
        }
        ////**** Address ****\\\\


        [HttpGet]
        public IActionResult AddNewAddress(int customerId)
        {
            AddressForCreationVm newAddress = new() { CustomerId = customerId };

            return PartialView("AddNewAddress", newAddress);
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddressForCreationVm address)
        {
            if (address.Btn == "Submit")
            {
                _addressService.AddNewAddress(address);
            }

            return Redirect("/Identity/Account/Manage/Addresses");
        }

        [HttpGet]
        public IActionResult ChangeAddress(int id)
        {
            AddressForCreationVm addressToBeEdited = _addressService.GetAddressToEdit(id);

            return PartialView("ChangeAddress", addressToBeEdited);
        }
        [HttpPost]
        public IActionResult ChangeAddress(AddressForCreationVm editedAddress)
        {
            if (editedAddress.Btn == "Submit")
            {
                _addressService.ChangeCustomerAddress(editedAddress);
            }
            return Redirect("/Identity/Account/Manage/Addresses");
        }
        [HttpGet]
        public IActionResult DeleteAddress(int id)
        {
            AddressForOrderViewVm address = _addressService.GetAddressToview(id);

            return PartialView("ConfirmDeleteAddress", address);
        }

        [HttpPost]
        public IActionResult DeleteAddress(bool isConfirmed, int id)
        {
            if (isConfirmed)
            {
                _addressService.DeleteAddress(id);
            }
            return Redirect("/Identity/Account/Manage/Addresses");
        }

        [HttpGet]
        public IActionResult ViewAddress(int addressId)
        {
            AddressForCreationVm address = _addressService.GetAddressToEdit(addressId);

            return View(address);
        }

        public ActionResult GetDeliveryAddressPartialView()
        {
            return PartialView("DeliveryAddress");
        }

        public ActionResult GetBillingAddressPartialView()
        {
            return PartialView("BillingAddress");
        }

        public IActionResult CartDropdownAddresses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                UserCustomerDetails currentUser = _userManager.FindByIdAsync(userId).Result;
                if (currentUser != null)
                {
                    List<AddressForOrderViewVm> list = _addressService.GetCustmersDeliveryAddresses(currentUser.CustomerId.Value);
                    ViewBag.CustomerId = currentUser.CustomerId.Value;
                    return PartialView("CartDropdownAddresses", list);
                }
            }

            return View("UserNotFound");
        }


    }
}
