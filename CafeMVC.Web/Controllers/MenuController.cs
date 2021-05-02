using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            var ListOfMenus = menuService.GetAllMenuType();
            return View(ListOfMenus);
        }
        
        public IActionResult VieWProductOfMenu(int menuTypeId)
        {
            var ListOfProductByMenu = menuService.GetAllProductOfMenuType(int menuTypeId);
            return View(ListOfProductByMenu);
        }

        public IActionResult ViewProduct(int productId)
        {
            var viewProduct = menuService.GetProductById(productId);
            return View(viewProduct);
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(ProductModel productModel)
        {
            menuService.AddNewProduct(productModel);
            return View();
        }
        [HttpGet]
        public IActionResult AddNewMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewMenu(MenutModel menuModel)
        {
            menuService.AddNewMenu(menuModel);
            return View();
        }
    }

}
