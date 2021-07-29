using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CafeMVC.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMenuService _menuService;

        private readonly IOrderService _orderService;

        private readonly IProductService _productService;

        public IActionResult Index()
        {
            ListOfOrdersVm allOrdersForView = _orderService.GetAllOrders();
            return View(allOrdersForView);
        }
        [HttpGet]
        public IActionResult OrderMenuView(int menuId)
        {
            Application.ViewModels.Menu.MenuForViewVm ListOfMenus = _menuService.GetAllProducstOfMenu(menuId);
            return View(ListOfMenus);
        }

        [HttpGet]
        public IActionResult OrderVieWProductOfMenu(int menuTypeId)
        {
            Application.ViewModels.Menu.MenuForViewVm ListOfProductByMenu = _menuService.GetAllProducstOfMenu(menuTypeId);
            return View(ListOfProductByMenu);
        }

        [HttpGet]
        public IActionResult VieWProductDetails(int productId)
        {
            Application.ViewModels.Products.ProductForViewVm product = _productService.GetProductDetails(productId);
            return View(product);
        }

        [HttpGet]
        public IActionResult ViewOrderProducts(int orderId)
        {
            Application.ViewModels.Products.ListOfProductsVm orderProductsList = _orderService.GetAllProducts(orderId);
            return View(orderProductsList);
        }

        [HttpGet]
        public IActionResult AddProductToOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductToOrder(int orderId, int productId)
        {
            _orderService.AddProductToOrder(orderId, productId);
            return View();
        }
        [HttpGet]
        public IActionResult DeleteProductFromOrder()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteProductFromOrder(int productId, int orderId)
        {
            _orderService.RemoveProduct(productId, orderId);
            return View();

        }
        [HttpGet]
        public IActionResult OrderSummary(int orderId)
        {
            OrderForSummaryVm orderForSummary = _orderService.GetOrderSummaryVmById(orderId);
            return View(orderForSummary);
        }

        [HttpPost]
        public IActionResult OrderSummary(OrderForCreationVm orderForView)
        {
            string orderConfirmation = _orderService.AddOrder(orderForView);
            return View(orderConfirmation);
        }

        [HttpGet]
        public IActionResult ChangeLeadTime(int orderId)
        {
            DateTime LeadtimeOfOrder = _orderService.GetOrderForCreationVmById(orderId).LeadTime;
            return View(LeadtimeOfOrder);
        }

        [HttpPatch]
        public IActionResult ChangeLeadTime(DateTime leadTimeOfOrder, int orderId)
        {
            _orderService.ChangeLeadTime(orderId, leadTimeOfOrder);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeDeliveryAddress(int orderId)
        {
            List<AddressForCreationVm> DeliveryAddress = _orderService.GetOrderForCreationVmById(orderId).Addresses;
            return View(DeliveryAddress);
        }

        [HttpPatch]
        public IActionResult ChangeDeliveryAddress(AddressForCreationVm deliveryAddress, int orderId)
        {
            _orderService.ChangeDeliveryAddress(orderId, deliveryAddress);
            return View();
        }

        [HttpGet]
        public IActionResult AddAnntotation()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult AddAnntotation(string annotation, int orderId)
        {
            _orderService.AddOrChangeNote(orderId, annotation);
            return View();
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
        public IActionResult CanceleOrder(int orderId)
        {
            _orderService.CanceleOrder(orderId);
            return View();
        }

        [HttpGet]
        public IActionResult CloseOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CloseOrder(int orderId)
        {
            _orderService.CloseOrder(orderId);
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
