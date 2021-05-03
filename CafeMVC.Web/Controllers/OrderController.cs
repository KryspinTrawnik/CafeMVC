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
            return View();
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
        [HttpPost]
        public IActionResult OrderVieWProductsByMenuType(int orderId, ProductForView productForView)
        {
            orderService.AddProductToOrder(orderId, productForView);
            return View();
        }
        [HttpGet]
        public IActionResult VieWProductDetails(int productId)
        {
            var product = menuService.GetProductDetails(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult VieWProductDetails(ProductForView productForView)
        {
            orderService.AddProductToOrder(productForView);
            return View();
        }
        [HttpGet]
        public IActionResult ViewOrderProducts(int orderId)
        {
            var orderProductsList = orderService.GetAllProducts(orderID);
            View(orderProductsList);
        }
        [HttpPut]
        public IActionResult ViewOrderProducts(int orderId, ProductForView productForView)
        {
            orderService.AddProductToOrder(productForView);
            return View();
        }
        [HttpDelete]
        public IActionResult RemoveProductFromOrder(int productId)
        {
            orderService.RemoveProduct(productId);
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
            orderService.ConfirmOrder(orderForView);
            return View();
        }

    }
}
