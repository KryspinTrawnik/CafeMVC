using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMVC.Web.Areas.Identity.Pages.Account.Manage
{
    public class OrdersModel : PageModel
    {
        private readonly UserManager<UserCustomerDetails> _userManager;
        private readonly SignInManager<UserCustomerDetails> _signInManager;
        public IAddressService _addressService { get; set; }
        public List<AddressForSummaryVm> Addresses { get; set; }

        public int CustomerId { get; set; }

        public OrdersModel(UserManager<UserCustomerDetails> userManager,
            SignInManager<UserCustomerDetails> signInManager, IAddressService addressService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _addressService = addressService;

        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            await LoadAsync(user);
            return Page();
            
        }

        private async Task LoadAsync(UserCustomerDetails user)
        {
            Addresses = await _addressService.GetAllAddressesByCustomerId(user.CustomerId.Value);
            CustomerId = user.CustomerId.Value;
            
        }
    }
}
