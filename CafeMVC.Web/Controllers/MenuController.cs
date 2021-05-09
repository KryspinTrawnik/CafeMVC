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
        
        public IActionResult VieWProductsByMenuType(int menuTypeId)
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
        public IActionResult AddNewProductToMenu()
        {
            var listOfAllProducts = menuService.GetAllProducts();
            var listOfAllMenuType = menuService.GetAllMenuType();
            return View(listOfAllProducts, listOfAllMenuType);
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
        public IActionResult AddNewIngredient()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewIngredient(IngredienttModel ingredientModel)
        {
            menuService.AddNewMenu(ingredientModel);
            return View();
        }
        
        [HttpGet]
        public IActionResult ChangeNameOfProduct( int productId)
        {
            var productForChange = menuService.GetProductById(productId);
            return View();
        }
        
        [HttpPatch]
        public IActionResult ChangeNameOfProduct( ProductModel productModel)
        {
            menuService.UpdateProductName(productModel);
            return View();
        }
        
        [HttpGet]
        public IActionResult AddIngredientsToProduct(int productId)
        {
            var productForChange = menuService.GetProductById(productId);
            return View();
        }
        
        [HttpPatch]
        public IActionResult AddIngredientsToProduct(int productId, int ingredientId)
        {
            menuService.AddIngredients(productId, ingredientId);
            return View();
        }

        [HttpGet]
        public IActionResult DeleteIngredientsFromProduct(int productId)
        {
            var productForChange = menuService.GetProductById(productId);
            return View();
        }
        
        [HttpPatch]
        public IActionResult AddIngredientsFromProduct(ProductModel productModel, int productId)
        {
            menuService.AddIngredients(productModel);
            return View();
        }
    }

}
