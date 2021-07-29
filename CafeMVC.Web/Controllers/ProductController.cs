using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public IActionResult Index()
        {
            var allProductsList = _productService.GetAllProducts();
            return View(allProductsList);
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View(new ProductForCreationVm());
        }

        [HttpPost]
        public IActionResult AddNewProduct(ProductForCreationVm product)
        {
            bool hasBeenAdded = _productService.AddNewProduct(product);
            return View(hasBeenAdded);
        }

        [HttpGet]
        public IActionResult ChangeNameOfProduct(int productId)
        {
            var productForChange = _productService.GetProductById(productId);
            return View(productForChange);
        }

        [HttpPatch]
        public IActionResult ChangeNameOfProduct(ProductForViewVm productModel)
        {
            _productService.UpdateProduct(productModel);
            return View();
        }
        [HttpGet]
        public IActionResult DeleteProduct()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            return View();
        }

        [HttpGet]
        public IActionResult ViewProduct(int productId)
        {
            var productView = _productService.GetProductById(productId);
            return View(productView);
        }

        [HttpGet]
        public IActionResult AddIngredientsToProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddIngredientsToProduct(int productId, int ingredientId)
        {
            _productService.AddIngredientToProduct(productId, ingredientId);
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
            _productService.DeleteIngredient(productId, ingredientId);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeDietInformation()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult ChangeDietInformation(int productId, DietInfoForViewVm dietInformation)
        {
            _productService.ChangeDietInformation(productId, dietInformation);
            return View();
        }
        [HttpGet]
        public IActionResult ViewAllIngredients()
        {
            var allIngredientsList = _productService.GetAllIngredients();
            return View(allIngredientsList);
        }

        [HttpGet]
        public IActionResult AddNewIngredient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewIngredient(IngredientForCreationVm ingredient)
        {
            _productService.AddNewIngredient(ingredient);
            return View();
        }
        [HttpGet]
        public IActionResult AddNewAllergen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAllergen(AllergenForViewVm allergen)
        {
            _productService.AddNewAllergen(allergen);
            return View();
        }

        [HttpGet]
        public IActionResult AddImageToProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImageToProduct(string pathway)
        {
            return View();
        }
    }
}
