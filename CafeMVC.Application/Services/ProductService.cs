using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
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

        public void AddIngredientToProduct(int productId, int ingredientId)
        {
            Product product = _productRepository.GetItemById(productId);
            product.Ingredients.Add(_productRepository.GetIngredientById(ingredientId));
            _productRepository.UpdateItem(product);
        }

        public void AddNewAllergen(AllergenForViewVm allergen)
        {
            Allergen newAllergen = _mapper.Map<Allergen>(allergen);
            
                _productRepository.AddNewAllergen(newAllergen);
            
        }

        public void AddNewImageToProduct(IFormFile image, int productId)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Images\\");
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);
            var fileName = Path.GetFileNameWithoutExtension(image.FileName);
            var filePath = Path.Combine(basePath, image.FileName);

            if (!File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyToAsync(stream);
                }
            }
            _productRepository.AddNewImageToProduct(fileName, productId);
        }

        public void AddNewIngredient(IngredientForCreationVm ingredient)
        {
            Ingredient newIngredient = _mapper.Map<Ingredient>(ingredient);
                _productRepository.AddNewIngredient(newIngredient);
            
        }

        public void AddNewProduct(ProductForCreationVm product)
        {
            Product newProduct = _mapper.Map<Product>(product);
            _productRepository.AddItem(newProduct);
             
        }

        public void DeleteImageFromProduct(int productId)
        {
            Product product = _productRepository.GetItemById(productId);
            File.Delete(product.ImagePath);
            product.ImagePath = null;
            _productRepository.UpdateItem(product);
        }

        public void DeleteIngredient(int productId, int ingredientId)
        {
            Product product = _productRepository.GetItemById(productId);
            product.Ingredients.Remove(product.Ingredients.FirstOrDefault(x => x.Id == ingredientId));
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteItem(productId);
        }

        public ListOfIngredientsVm GetAllIngredients()
        {
            List<IngredientForViewVm> allIngredients = _productRepository.GetAllIngredients()
                  .ProjectTo<IngredientForViewVm>(_mapper.ConfigurationProvider).ToList();
            ListOfIngredientsVm listOfIngredients = new()
            {
                Ingredients = allIngredients,
                Count = allIngredients.Count
            };
            return listOfIngredients;
        }

        public ListOfProductsVm GetAllProducts()
        {
            List<ProductForListVm> allProducts = _productRepository.GetAllType()
                .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList();
            ListOfProductsVm listOfAllProducts = new()
            {
                ListOfAllProducts = allProducts,
                Count = allProducts.Count
            };
            return listOfAllProducts;
        }

        public ProductForViewVm GetProductById(int productId)
        {
            Product product = _productRepository.GetItemById(productId);
            ProductForViewVm productForView = _mapper.Map<ProductForViewVm>(product);
            return productForView;
        }

        public void UpdateProduct(ProductForCreationVm productModel)
        {
            Product updatedProduct = _mapper.Map<Product>(productModel);
            _productRepository.UpdateItem(updatedProduct);
        }

        public void AddDietInfoToProduct(int dietInfoId, int productId)
        {
            DietInformation dietInformation = _productRepository.GetAllDietInfo().FirstOrDefault(x => x.Id == dietInfoId);
            _productRepository.AddDietInfoToProduct(dietInformation, productId);
        }

        public void DeleteDietInfoFromProduct(int dietInfoId, int productId)
        {
            _productRepository.RemoveDietInfoFromProduct(dietInfoId, productId);
        }
    }
}
