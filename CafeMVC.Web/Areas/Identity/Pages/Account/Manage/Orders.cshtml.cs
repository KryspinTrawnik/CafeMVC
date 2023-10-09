using CafeMVC.Application.Interfaces;
using CafeMVC.Application.Services;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMVC.Web.Areas.Identity.Pages.Account.Manage
{
    public class OrderModel : PageModel
    {
        private readonly UserManager<UserCustomerDetails> _userManager;
        private readonly SignInManager<UserCustomerDetails> _signInManager;
        public IOrderService _orderService { get; set; }
        public CustomerOrdersVm CustomerOrders  { get; set; }

        public int CustomerId { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public CustomerOrdersVm CustomerOrders { get; set; }

        }

        public OrderModel(UserManager<UserCustomerDetails> userManager,
            SignInManager<UserCustomerDetails> signInManager, IOrderService orderService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderService = orderService;

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
            CustomerOrders = new() { OrdersForUser = await _orderService.GetCustomerOrders(user.CustomerId.Value) };
            CustomerId = user.CustomerId.Value;
            Input = new InputModel { CustomerOrders = CustomerOrders } ;

        }
        
    }
}
