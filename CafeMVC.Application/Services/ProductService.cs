using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IIngredientService _ingredientService;
        private readonly IAllergenService _allergernService;


        public ProductService(IProductRepository productRepository, IMapper mapper, IIngredientService ingredientService, IAllergenService allergenService)
        {
            _allergernService = allergenService;
            _ingredientService = ingredientService;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        private string SaveImageOnFile(IFormFile newProductImage)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\Imgs\\");
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists)
            {
                Directory.CreateDirectory(basePath);
            }
            var fileName = Path.GetFileName(newProductImage.FileName);
            var filePath = Path.Combine(basePath, newProductImage.FileName);

            if (!File.Exists(filePath))
            {
                using FileStream stream = new FileStream(filePath, FileMode.Create);
                newProductImage.CopyTo(stream);

            }

            return fileName;
        }
        private Product AddjoiningTables(Product newProduct, ProductForCreationVm productVm)
        {
            newProduct.ProductIngredients = new List<ProductIngredient>();
            newProduct.ProductAllergens = new List<ProductAllergen>();
            newProduct.ProductDietInfoTags = new List<ProductDietInfoTag>();
            foreach (int item in productVm.IngredientsIds)
            {
                newProduct.ProductIngredients.Add(new ProductIngredient()
                {
                    IngredientId = item,
                });
            }
            foreach (int item in productVm.AllergensIds)
            {
                newProduct.ProductAllergens.Add(new ProductAllergen()
                {
                    AllergenId = item,
                });
            };
            foreach (int item in productVm.DietInfoIds)
            {
                newProduct.ProductDietInfoTags.Add(new ProductDietInfoTag()
                {
                    DietInfoTagId = item,
                });
            };
            return newProduct;
        }
        private Product PrepareProductForSaving(ProductForCreationVm newProductVm)
        {
            newProductVm.Price = Helper.StringToDouble(newProductVm.PriceString);
            if (newProductVm.File != null)
            {
                newProductVm.ImagePath = SaveImageOnFile(newProductVm.File);
            }
            else
            {
                newProductVm.ImagePath = newProductVm.ImagePath.Substring(8);
            }
            return AddjoiningTables(_mapper.Map<Product>(newProductVm), newProductVm);
        }

        private List<DietInfoForViewVm> GetAllDietInfo() => _productRepository.GetAllDietInfo()
            .ProjectTo<DietInfoForViewVm>(_mapper.ConfigurationProvider).ToList();

        private List<DietInfoForViewVm> GetAllProductDietInfo(int productId) => _productRepository.GetAllProductDietInfo(productId)
            .Select(x => x.DietInfoTag).ProjectTo<DietInfoForViewVm>(_mapper.ConfigurationProvider).ToList();

        private void UpdateProductDieteInfoTagTable(int productId, List<ProductDietInfoTag> productDietInfoTag)
        {
            List<ProductDietInfoTag> allProductDietInfoTags = _productRepository.GetAllProductDietInfo(productId).ToList();
            List<ProductDietInfoTag> toBeRemoved = allProductDietInfoTags.Except(productDietInfoTag, new Helper()).ToList();
            if (toBeRemoved != null)
            {
                for (int i = 0; i < toBeRemoved.Count; i++)
                {
                    _productRepository.RemoveDietInfoFromProduct(toBeRemoved[i]);
                }
            }
            List<ProductDietInfoTag> toBeAdded = productDietInfoTag
                .Except(_productRepository.GetAllProductDietInfo(productId), new Helper()).ToList();
            if (toBeAdded != null)
            {
                for (int i = 0; i < toBeAdded.Count; i++)
                {
                    toBeAdded[i].ProductId = productId;
                    _productRepository.AddDietInfoToProduct(toBeAdded[i]);
                }
            }
        }
        private void UpdateJoningTables(Product product)
        {

            _ingredientService.UpdateProductIngredientTable(product.Id, product.ProductIngredients.ToList());
            _allergernService.UpdateProductAllergenTable(product.Id, product.ProductAllergens.ToList());
            UpdateProductDieteInfoTagTable(product.Id, product.ProductDietInfoTags.ToList());
        }
        public void AddNewProduct(ProductForCreationVm productVm)
        {
            _productRepository.AddNewProduct(PrepareProductForSaving(productVm));
        }

        public ProductForEditionVm GetProductForEdtitionById(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            ProductForEditionVm productForEdition = _mapper.Map<ProductForEditionVm>(product);
            productForEdition.Allergens = _allergernService.GetAllProductAllergens(productId);
            productForEdition.DietInfoForViewVms = GetAllProductDietInfo(productId);
            productForEdition.Ingredients = _ingredientService.GetProductAllIngredients(productId);
            List<AllergenForViewVm> residualAllergens = _allergernService.GetAllAllergens().Except(productForEdition.Allergens, new Helper()).ToList();
            productForEdition.AllAllergens = residualAllergens;
            List<IngredientForViewVm> residualIngredients = _ingredientService.GetAllIngredients().Except(productForEdition.Ingredients, new Helper()).ToList();
            productForEdition.AllIngredients = residualIngredients;
            productForEdition.AllDietInfoForViewVms = GetAllDietInfo();
            productForEdition.PriceString = productForEdition.Price.ToString();

            productForEdition.ImagePath = $"../Imgs/{productForEdition.ImagePath}";

            return productForEdition;
        }

        public void DeleteProduct(int productId)
        {
            DeleteImageFromProduct(productId);
            _productRepository.DeleteProduct(productId);
        }
        public ListOfProductsVm GetAllProducts(int pageSize, int pageNo, string searchString)
        {
            List<ProductForListVm> allProducts = _productRepository.GetAllProducts().Where(x => x.Name.StartsWith(searchString))
                .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList();
            List<ProductForListVm> productsToDisplay = allProducts.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListOfProductsVm listOfAllProducts = new()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                ListOfAllProducts = productsToDisplay,
                Count = allProducts.Count
            };

            return listOfAllProducts;
        }
        public void DeleteImageFromProduct(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\Imgs\\" + product.ImagePath);
            if (File.Exists(basePath))
            {
                File.Delete(basePath);
            }
            product.ImagePath = null;
            _productRepository.UpdateProduct(product);
        }

        public ProductForViewVm GetProductForViewById(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            ProductForViewVm productForView = _mapper.Map<ProductForViewVm>(product);
            productForView.Allergens = _allergernService.GetAllProductAllergens(productId);
            productForView.DietInformations = GetAllProductDietInfo(productId);
            productForView.Ingredients = _ingredientService.GetProductAllIngredients(productId);
            productForView.BasePath = $"../Imgs/{productForView.ImagePath}";

            return productForView;
        }

        public void UpdateProduct(ProductForEditionVm productModel)
        {
            Product product = PrepareProductForSaving(productModel);
            UpdateJoningTables(product);
            _productRepository.UpdateProduct(product);
        }

        public ProductForCreationVm GetProductForCreation()
        {
            return new ProductForCreationVm()
            {
                Allergens = _allergernService.GetAllAllergens(),
                Ingredients = _ingredientService.GetAllIngredients(),
                DietInfoForViewVms = GetAllDietInfo()
            };
        }
    }
}
