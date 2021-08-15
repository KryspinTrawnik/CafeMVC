using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace CafeMVC.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ListOfProductsVm allProductsList = _productService.GetAllProducts(2, 1, "");
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
            }
            ListOfProductsVm allProductsList = _productService.GetAllProducts(pageSize, pageNo.Value, searchString);
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
            _productService.AddNewProduct(product);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeNameOfProduct(int productId)
        {
            ProductForCreationVm productForChange = _productService.GetProductForCreationById(productId);
            return View(productForChange);
        }

        [HttpPatch]
        public IActionResult ChangeNameOfProduct(ProductForCreationVm productModel)
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
            ProductForViewVm productView = _productService.GetProductForViewById(productId);
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
        public IActionResult DeleteIngredientsFromProduct(int productId, int ingredientId)
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
        public IActionResult AddDietInfo(int productId, int dietInfoId)
        {
            _productService.AddDietInfoToProduct(productId, dietInfoId);
            return View();
        }
        [HttpGet]
        public IActionResult ViewAllIngredients()
        {
            ListOfIngredientsVm allIngredientsList = _productService.GetAllIngredients();
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
