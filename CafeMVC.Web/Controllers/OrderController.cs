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
        public IActionResult OrderVieWProductOfMenu(OrderModel orderModel)
        {
            var ListOfProductByMenu = menuService.GetAllProductOfMenuType(int menuTypeId);
            return View();
        }
    }
}
