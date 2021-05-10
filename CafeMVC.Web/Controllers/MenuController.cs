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

        [HttpGet]
        public IActionResult VieWProductsByMenuType(int menuTypeId)
        {
            var ListOfProductByMenu = menuService.GetAllProductOfMenuType(int menuTypeId);
            return View(ListOfProductByMenu);
        }

        [HttpGet]
        public IActionResult ViewProduct(int productId)
        {
            var viewProduct = productService.GetProductById(productId);
            return View(viewProduct);
        }

        [HttpGet]
        public IActionResult ViewMenuProductsByDieteInfo(int menuTypeId, DieteInfoModel dieteInfo)
        {
            var productsByDieteInfo = menuService.GetProductByDieteInfo(dieteInfo);
            return View(productsByDieteInfo);
        }

        [HttpGet]
        public IActionResult AddNewProductToMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProductToMenu(ProductModel product, int menuId)
        {
            menuService.AddProductToMenu(product, menuId);
            return View();
        }

        [HttpGet]
        public IActionResult DeleteProductFromMenu()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteProductFromMenu(ProductModel product, int menuId)
        {
            menuService.DeleteProductFromMenu(product, menuId);
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

        [HttpGet]
        public IActionResult DeleteMenu()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteMenu(int menuId)
        {
            menuService.DeleteMenu(menuId);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeMenu()
        {
            return View();
        }
        [HttpPatch]
        public IActionResult ChangeMenu(MenuModel menuModel)
        {
            menuService.ChangeMenu(menuModel);
            return View();
        }
    }
}
