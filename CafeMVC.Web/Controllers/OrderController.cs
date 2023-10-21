using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CafeMVC.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        public OrderController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ListsOfOrdersForIndexVm ordersForView = _orderService.GetOrdersForIndex();

            return View(ordersForView);
        }


        [HttpGet]
        public IActionResult Cart()
        {
            OrderForCreationVm orderForCart = _orderService.GetOrderForCart(HttpContext.Session);

            return View(orderForCart);
        }

        [HttpGet]
        public IActionResult CustomerInfo(CartInformation cartInformation)
        {
            OrderForCreationVm newOrder = _cartService.GetOrderFromCart(cartInformation, HttpContext.Session);
            newOrder.Payment.PaymentType.Name = cartInformation.PaymentName;

            return View(newOrder);
        }

        [HttpGet]
        public IActionResult OrderView(int orderId)
        {
            OrderForViewVm order = _orderService.GetOrderToView(orderId);

            return View(order);
        }


        [HttpGet]
        public IActionResult OrderViewPartial(int orderId)
        {
            OrderForViewVm order = _orderService.GetOrderToView(orderId);

            return PartialView("OrderViewPartial", order);
        }

        [HttpPost]
        public IActionResult AddProductToCart(int quantity, int productId, int menuId)
        {
            _cartService.AddProductToCart(quantity, productId, HttpContext.Session);

            return RedirectToAction("ViewMenu", "Menu", new { menuId = menuId });
        }

        public IActionResult UpdateCartProduct(int quantity, int productId)
        {
            _cartService.UpdateCartProduct(quantity, productId, HttpContext.Session);

            return RedirectToAction("Cart");

        }

        public IActionResult RemoveProductFromCart(int id)
        {
            _cartService.RemoveProductFromCart(id, HttpContext.Session);

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public IActionResult OrderSummary(int orderId)
        {
            OrderForSummaryVm orderSummary = _orderService.GetOrderSummaryVmById(orderId);

            return View(orderSummary);
        }


        [HttpGet]
        public IActionResult Checkout(OrderForCreationVm newOrder, string Btn)
        {
            if (Btn == "Submit")
            {
                OrderForCreationVm order = _cartService.UpdateOrderForCheckout(newOrder, HttpContext.Session);

                return View(order);

            }
            else
            {
                return RedirectToAction("Cart");
            }
        }

        [HttpPost]
        public IActionResult PlaceOrder(OrderForCreationVm newOrder)
        {
            int id = _orderService.AddOrder(newOrder, HttpContext.Session);

            return RedirectToAction("OrderSummary", new { orderId = id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeOrderStatus(int orderId, int statusId)
        {
            _orderService.ChangeOrderStatus(orderId, statusId);

            return RedirectToAction("OrderView", new { orderId = orderId });
        }

        [HttpGet]
        public IActionResult ChangeCustomerInfo(int orderId)
        {

            return View();
        }

        [HttpPost]
        public IActionResult ChangeCustomerInfo()
        {
            return RedirectToAction("OrderView");
        }

        
    }
}
