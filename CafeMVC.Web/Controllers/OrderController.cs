using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            var allOrdersForView = menuService.GetAllOrders();
            return View(allOrdersForView);
        }

        public IActionResult OrderMenuView()
        {
            var ListOfMenus = menuService.GetAllMenuType();
            return View();
        }

        [HttpGet]
        public IActionResult OrderVieWProductOfMenu(int menuTypeId)
        {
            var ListOfProductByMenu = menuService.GetAllProductOfMenuType(int menuTypeId);
            return View(ListOfProductByMenu);
        }
        
        [HttpGet]
        public IActionResult VieWProductDetails(int productId)
        {
            var product = menuService.GetProductDetails(productId);
            return View(product);
        }
        
        [HttpGet]
        public IActionResult ViewOrderProducts(int orderId)
        {
            var orderProductsList = orderService.GetAllProducts(orderId);
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
            orderService.AddProductToOrder(orderId, productId);
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
            orderService.RemoveProduct(productId, orderId);
            return View();
        }

        [HttpGet]
        public IActionResult OrderSummary(int orderId)
        {
            var orderForSummary = orderService.GetOrderbyId(orderId);
            return View(orderForSummary);
        }

        [HttpPost]
        public IActionResult OrderSummary(OrderForView orderForView)
        {
            var orderConfirmation = orderService.ConfirmOrder(orderForView);
            return View(orderConfirmation);
        }

        [HttpGet]
        public IActionResult ChangeLeadTime(int orderId)
        {
            var LeadtimeOfOrder = orderService.GetOrderbyId(orderId).LeadTime;
            return View(LeadtimeOfOrder);
        }

        [HttpPatch]
        public IActionResult ChangeLeadTime(DateTime leadTimeOfOrder, int orderId)
        {
            orderService.ChangeLeadTime(orderId, leadTimeOfOrder);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeDeliveryAddress()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult ChangeDeliveryAddress(DeliveryAddress address, int orderId)
        {
            orderService.ChangeDeliveryTime(orderId, address);
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
            orderService.AddAnnotation(orderId, annotation);
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
            orderService.ChangeAnnotation(orderId, annotation);
            return View();
        }
        [HttpGet]
        public IActionResult CanceleOrder(int orderId)
        {
            var orderToBeCancelled = orderService.GetOrderbyId(orderId);
            return View(orderToBeCancelled);
        }

        [HttpDelete]
        public IActionResult CanceleOrder(OrderForVM orderToBeCancelled)
        {
            orderService.CanceleOrder(orderToBeCancelled);
            return View();
        }

    }
}
