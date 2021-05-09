using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var allProductsList = productService.GetAllProducts();
            return View();
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(ProductModel productModel)
        {
            productService.AddNewProduct(productModel);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeNameOfProduct(int productId)
        {
            var productForChange = productService.GetProductById(productId);
            return View();
        }

        [HttpPatch]
        public IActionResult ChangeNameOfProduct(ProductModel productModel)
        {
            productService.UpdateProductName(productModel);
            return View();
        }
        [HttpGet]
        public IActionResult DeleteProduct()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(ProductModel productModel)
        {
            productService.UpdateProductName(productModel);
            return View();
        }

        [HttpGet]
        public IActionResult ViewProduct(int productId)
        {
            var productView = productService.GetProductById(productId);
        }

        [HttpGet]
        public IActionResult AddIngredientsToProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddIngredientsToProduct(int productId, int ingredientId)
        {
            productService.AddIngredientToProduct(productId, ingredientId);
            return View();
        }

        [HttpGet]
        public IActionResult DeleteIngredientsFromProduct()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteIngredientsFromProduct( int productId, int ingredientId)
        {
            productService.AddIngredients(productId, ingredientId);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeDietInformation()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult ChangeDietInformation(int productId, DietInformation dietInformation)
        {
            ingredientAndAllergenService.ChangeDietInformation(productId, ingredientId);
            return View();
        }
        [HttpGet]
        public IActionResult ViewAllIngredients()
        {
            var allIngredientsList = ingredientAndAllergenService.GetAllIngredients();
            return View(allIngredientsList);
        }

        [HttpGet]
        public IActionResult AddNewIngredient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewIngredient(IngredientModel ingredient)
        {
            ingredientAndAllergenService.AddNewIngredient(ingredient);
            return View();
        }


    }
}
