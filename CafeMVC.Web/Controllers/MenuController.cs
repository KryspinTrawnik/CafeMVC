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
        public MenuController(IMenuService menuService, IProductService productService)
        {
            _menuService = menuService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ListOfMenus = _menuService.GetAllMenus(2, 1, "");
            return View(ListOfMenus);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if(!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = string.Empty;
            }
            var ListOfMenus = _menuService.GetAllMenus(pageSize,pageNo.Value, searchString);
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
            var viewProduct = _productService.GetProductForViewById(productId);
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
        public IActionResult AddNewProductToMenu(int productId, int menuId)
        {
            _menuService.AddProductToMenu(productId, menuId);
            return View();
        }

        [HttpGet]
        public IActionResult DeleteProductFromMenu()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteProductFromMenu(int productId, int menuId)
        {
            _menuService.DeleteProductFromMenu(productId, menuId);
            return View();
        }
        [HttpGet]
        public IActionResult AddNewMenu()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewMenu(MenuForCreationVm menuModel)
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
            return View(menu);
        }
        [HttpPatch]
        public IActionResult ChangeMenu(MenuForViewVm menuModel)
        {
            _menuService.ChangeMenu(menuModel);
            return View();
        }
    }
}
