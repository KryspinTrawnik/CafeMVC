using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Menu;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IProductService _productService;
        public IActionResult Index()
        {
            var ListOfMenus = _menuService.GetAllMenuType();
            return View(ListOfMenus);
        }

        [HttpGet]
        public IActionResult VieWProductsByMenuType(int menuTypeId)
        {
            var ListOfProductByMenu = _menuService.GetAllProducstOfMenu(menuTypeId);
            return View(ListOfProductByMenu);
        }

        [HttpGet]
        public IActionResult ViewProduct(int productId)
        {
            var viewProduct = _productService.GetProductById(productId);
            return View(viewProduct);
        }

        [HttpGet]
        public IActionResult ViewMenuProductsByDieteInfo(int menuTypeId, DietInfoForViewVm dieteInfo)
        {
            var productsByDieteInfo = _menuService.GetProductsByDieteInfo(dieteInfo, menuTypeId);
            return View(productsByDieteInfo);
        }

        [HttpGet]
        public IActionResult AddNewProductToMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProductToMenu(ProductForListVm product, int menuId)
        {
            _menuService.AddProductToMenu(product, menuId);
            return View();
        }

        [HttpGet]
        public IActionResult DeleteProductFromMenu()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteProductFromMenu(ProductForListVm product, int menuId)
        {
            _menuService.DeleteProductFromMenu(product, menuId);
            return View();
        }
        [HttpGet]
        public IActionResult AddNewMenu()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewMenu(MenuCreationVm menuModel)
        {
            _menuService.AddNewMenu(menuModel);
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
            _menuService.DeleteMenu(menuId);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeMenu(int menuId)
        {
            var menu =_menuService.GetAllProducstOfMenu(menuId);
            return View();
        }
        [HttpPatch]
        public IActionResult ChangeMenu(MenuForVm menuModel)
        {
            _menuService.ChangeMenu(menuModel);
            return View();
        }
    }
}
