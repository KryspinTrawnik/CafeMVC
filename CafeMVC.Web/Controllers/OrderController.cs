using CafeMVC.Application.Helpers;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CafeMVC.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IAddressService _addressService;

        private readonly ICartService _cartService;

        public OrderController(IOrderService orderService, IAddressService addressService, ICartService cartService)
        {
            _orderService = orderService;
            _addressService = addressService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ListOfOrdersVm ordersForView = _orderService.GetOrdersToDisplay(2, 1, "");
            return View(ordersForView);
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
            }
            ListOfOrdersVm ordersForView = _orderService.GetOrdersToDisplay(pageSize, pageNo.Value, searchString);

            return View(ordersForView);
        }

        [HttpGet]
        public IActionResult Cart()
        {
            OrderForCreationVm orderForCart = _cartService.GetProductForCart(HttpContext.Session);
           
            return View(orderForCart);
        }

        [HttpGet]
        public IActionResult OrderView(int orderId)
        {
            OrderForViewVm order = _orderService.GetOrderToView(orderId);

            return View(order);
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
       
        [HttpPost]
        public IActionResult OrderSummary(int orderId)
        {
            OrderForSummaryVm orderConfirmation = _orderService.GetOrderSummaryVmById(orderId);

            return View(orderConfirmation);
        }

        [HttpGet]
        public IActionResult CustomerInfo(bool isCollection)
        {
            OrderForCreationVm newOrder = new()
            { IsCollection = isCollection};

            return View(newOrder);
        }

        [HttpGet]
        public IActionResult Checkout(OrderForCreationVm newOrder)
        {
            return View(newOrder);
        }
        
        [HttpPost]
        public IActionResult PlaceOrder(OrderForCreationVm newOrder)
        {
            int id = _orderService.AddOrder(newOrder, HttpContext.Session);

            return RedirectToAction("OrderSummary", new { orderId = id });

        }


        [HttpGet]
        public IActionResult ChangeAnntotation()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult ChangeAnntotation(string annotation, int orderId)
        {
            _orderService.AddOrChangeNote(orderId, annotation);
            
            return View();
        }

        [HttpGet]
        public IActionResult CanceleOrder()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult CanceleOrder(int orderId, int statusId)
        {
            _orderService.ChangeOrderStatus(orderId, statusId);

            return View();
        }


        public IActionResult CloseOrder(int orderId, int statusId)
        {
            _orderService.ChangeOrderStatus(orderId, statusId);
            
            return View();
        }

        [HttpGet]
        public IActionResult ViewOpenOrders()
        {
            ListOfOrdersVm openOrders = _orderService.GetAllOpenOrders();
            
            return View(openOrders);
        }
    }
}
