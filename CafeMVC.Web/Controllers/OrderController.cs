using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMenuService _menuService;

        private readonly IOrderService _orderService;

        private readonly IProductService _productService;
        public IActionResult Index()
        {
            var allOrdersForView = _orderService.GetAllOrders();
            return View(allOrdersForView);
        }
        [HttpGet]
        public IActionResult OrderMenuView(int menuId)
        {
            var ListOfMenus = _menuService.GetAllProducstOfMenu(menuId);
            return View(ListOfMenus);
        }

        [HttpGet]
        public IActionResult OrderVieWProductOfMenu(int menuTypeId)
        {
            var ListOfProductByMenu = _menuService.GetAllProducstOfMenu(menuTypeId);
            return View(ListOfProductByMenu);
        }
        
        [HttpGet]
        public IActionResult VieWProductDetails(int productId)
        {
            var product = _productService.GetProductDetails(productId);
            return View(product);
        }
        
        [HttpGet]
        public IActionResult ViewOrderProducts(int orderId)
        {
            var orderProductsList = _orderService.GetAllProducts(orderId);
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
            var orderForSummary = _orderService.GetOrderbyId(orderId);
            return View(orderForSummary);
        }

        [HttpPost]
        public IActionResult OrderSummary(OrderSummaryForViewVm orderForView)
        {
             var orderConfirmation =_orderService.AddOrder(orderForView);
            return View(orderConfirmation);
        }

        [HttpGet]
        public IActionResult ChangeLeadTime(int orderId)
        {
            var LeadtimeOfOrder = _orderService.GetOrderbyId(orderId).DeliveryTime;
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
            var DeliveryAddress = _orderService.GetOrderbyId(orderId).DeliveryAddress;
            return View(DeliveryAddress);
        }

        [HttpPatch]
        public IActionResult ChangeDeliveryAddress(string deliveryAddress, int orderId)
        {
            _orderService.ChangeDeliveryTime(orderId, deliveryAddress);
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
            _orderService.AddAnnotation(orderId, annotation);
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
            _orderService.ChangeAnnotation(orderId, annotation);
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

    }
}
