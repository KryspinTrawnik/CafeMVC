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

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        private string AddImageToNewProduct(IFormFile newProductImage)
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
            newProductVm.ImagePath = AddImageToNewProduct(newProductVm.File);

            return AddjoiningTables(_mapper.Map<Product>(newProductVm), newProductVm);
        }
        public void AddNewProduct(ProductForCreationVm productVm)
        {
            _productRepository.AddNewProduct(PrepareProductForSaving(productVm));
        }

        public ProductForCreationVm GetProductForEdtitionById(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            ProductForCreationVm productForCreation = _mapper.Map<ProductForCreationVm>(product);

            return productForCreation;
        }

        public void DeleteProduct(int productId)
        {
            DeleteImageFromProduct(productId);
            _productRepository.DeleteProduct(productId);
        }
        public ListOfProductsVm GetAllProducts(int pageSize, int pageNo, string searchString)
        {
            List<ProductForListVm> allProducts = _productRepository.GetAllProducts()
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
        public void AddNewImageToProduct(IFormFile image, int productId)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Imgs\\");
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists)
            {
                Directory.CreateDirectory(basePath);
            }
            var fileName = Path.GetFileName(image.FileName);
            var filePath = Path.Combine(basePath, image.FileName);

            if (!File.Exists(filePath))
            {
                using var stream = new FileStream(filePath, FileMode.Create);
                image.CopyTo(stream);
            }
            _productRepository.AddNewImageToProduct(fileName, productId);
        }

        public ProductForViewVm GetProductForViewById(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            ProductForViewVm productForView = _mapper.Map<ProductForViewVm>(product);
            productForView.Allergens = _productRepository.GetAllAllergensFromProduct(productId)
                .ProjectTo<AllergenForViewVm>(_mapper.ConfigurationProvider).ToList();
            productForView.DietInformations = _productRepository.GetAllProductDietInfo(productId)
                .ProjectTo<DietInfoForViewVm>(_mapper.ConfigurationProvider).ToList();
            productForView.Ingredients = _productRepository.GetAllProductIngredients(productId)
                .ProjectTo<IngredientForViewVm>(_mapper.ConfigurationProvider).ToList();
            productForView.BasePath = $"../Imgs/{productForView.ImagePath}";
            return productForView;
        }

        public void UpdateProduct(ProductForCreationVm productModel)
        {
            Product updatedProduct = _mapper.Map<Product>(productModel);
            _productRepository.UpdateProduct(updatedProduct);
        }

        public void AddDietInfoToProduct(int dietInfoId, int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            DietInfoTag dietInfoTag = _productRepository.GetDietInfoTagById(dietInfoId);
            _productRepository.AddDietInfoToProduct(new ProductDietInfoTag
            {
                Product = product,
                ProductId = productId,
                DietInfoTag = dietInfoTag,
                DietInfoTagId = dietInfoId
            });
        }

        public void DeleteDietInfoFromProduct(int dietInfoId, int productId)
        {
            ProductDietInfoTag productDietInfoTagToBeRemoved = _productRepository
                .GetProductById(productId).ProductDietInfoTags.FirstOrDefault(x => x.DietInfoTagId == dietInfoId);
            _productRepository.RemoveDietInfoFromProduct(productDietInfoTagToBeRemoved);
        }

        public ProductForCreationVm GetProductForCreation()
        {
            return new ProductForCreationVm()
            {
                Allergens = _productRepository.GetAllAllergens().ProjectTo<AllergenForViewVm>(_mapper.ConfigurationProvider).ToList(),
                Ingredients = _productRepository.GetAllIngredients().ProjectTo<IngredientForViewVm>(_mapper.ConfigurationProvider).ToList(),
                DietInfoForViewVms = _productRepository.GetAllDietInfo().ProjectTo<DietInfoForViewVm>(_mapper.ConfigurationProvider).ToList()
            };
        }

    }
}
