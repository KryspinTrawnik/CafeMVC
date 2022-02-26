using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

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
            _productService.AddNewProduct(product);
            return View();
        }

        [HttpGet]
        public IActionResult ChangeNameOfProduct(int productId)
        {
            ProductForCreationVm productForChange = _productService.GetProductForEdtitionById(productId);
            return View(productForChange);
        }

        [HttpPatch]
        public IActionResult ChangeNameOfProduct(ProductForCreationVm productModel)
        {
            _productService.UpdateProduct(productModel);
            return View();
        }
    

        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
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

        [HttpGet]
        public IActionResult ViewProduct(int productId)
        {
            ProductForViewVm productView = _productService.GetProductForViewById(productId);
            return View(productView);
        }
        ///***Ingredient Actions***///
        [HttpGet]
        public IActionResult AddIngredientsToProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddIngredientsToProduct(int productId, int ingredientId)
        {
            _ingredientService.AddIngredientToProduct(productId, ingredientId);
            return View();
        }

        [HttpGet]
        public IActionResult DeleteIngredientsFromProduct()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewAllIngredients()
        {
            ListOfIngredientsVm allIngredientsList = _ingredientService.GetAllIngredients();
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
            _ingredientService.AddNewIngredient(ingredient);
            return View();
        }
        public IActionResult DeleteIngredientsFromProduct(int productId, int ingredientId)
        {
            _ingredientService.DeleteIngredient(productId, ingredientId);
            return View();
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
