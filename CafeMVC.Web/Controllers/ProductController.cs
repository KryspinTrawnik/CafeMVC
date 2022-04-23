using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CafeMVC.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IIngredientService _ingredientService;
        private readonly IAllergenService _allergenService;


        public ProductController(IProductService productService, IAllergenService allergenService,IIngredientService ingredientService )
        {
            _productService = productService;
            _allergenService = allergenService;
            _ingredientService = ingredientService;
        }
        ///*** Product Actions ***\\\
        [HttpGet]
        public IActionResult Index()
        {
            ListOfProductsVm allProductsList = _productService.GetAllProducts(20, 1, "");
            return View(allProductsList);
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
                pageSize = 20;
            }
            ListOfProductsVm allProductsList = _productService.GetAllProducts(pageSize, pageNo.Value, searchString);
            return View(allProductsList);
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View(_productService.GetProductForCreation());
        }

        [HttpPost]
        public IActionResult AddNewProduct(ProductForCreationVm product)
        {
            if (product.Btn == "Submit")
            {
            _productService.AddNewProduct(product);
            }
            
             return RedirectToAction("index");
        }

        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewProduct(int productId)
        {
            ProductForViewVm productView = _productService.GetProductForViewById(productId);
            
            return View(productView);
        }

        [HttpGet]
        public IActionResult EditProduct( int productId)
        {
            ProductForEditionVm productForEdtiting = _productService.GetProductForEdtitionById(productId);
            
            return View(productForEdtiting);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductForEditionVm editedProduct)
        {
            if (editedProduct.Btn == "Submit")
            {
                _productService.UpdateProduct(editedProduct);
            }
                return RedirectToAction("Index");
        }

        ///***Ingredient Actions***///
    
        public IActionResult DeleteIngredient(int ingredientId)
        {
            _ingredientService.DeleteIngredient(ingredientId);
            
            return RedirectToAction("EditAllIngredients");
        }

        [HttpGet]
        public IActionResult EditAllIngredients()
        {
            return View(_ingredientService.GetListIngredientsForEdition(20, 1, ""));
        }
        [HttpPost]
        public IActionResult EditAllIngredients(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = string.Empty;
                pageSize = 20;
            }
            
            var ingredientsForEditionList = _ingredientService.GetListIngredientsForEdition(pageSize, pageNo.Value, searchString);
            return View(ingredientsForEditionList);
        }

        [HttpGet]
        public IActionResult AddNewIngredient()
        {
            return View(new IngredientForViewVm());
        }

        [HttpPost]
        public IActionResult AddNewIngredient(IngredientForViewVm ingredient)
        {
            if (ingredient.Btn == "Submit")
            {
            _ingredientService.AddNewIngredient(ingredient);
            }
            return RedirectToAction("EditAllIngredients");
        }
       
        ///***Diet info Actions***///
        [HttpGet]
        public IActionResult ChangeDietInformation()
        {
            return View();
        }

        [HttpPatch]
        public IActionResult AddDietInfo(int productId, int dietInfoId)
        {
            _productService.AddDietInfoToProduct(productId, dietInfoId);
            return View();
        }

        ///***Allergen Actions***///
        [HttpGet]
        public IActionResult AddNewAllergen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAllergen(AllergenForViewVm allergen)
        {
            _allergenService.AddNewAllergen(allergen);
            return View();
        }


    }
}
