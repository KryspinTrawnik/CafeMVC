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
using System.Web.Mvc;

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

        public void AddNewProduct(ProductForCreationVm product)
        {
            ProductForCreationVm productWithAddedPicture = AddImageToNewProduct(product);
            Product newProduct = _mapper.Map<Product>(productWithAddedPicture);
            _productRepository.AddNewProduct(newProduct);

        }

        public ProductForCreationVm GetProductForEdtitionById(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            ProductForCreationVm productForCreation = _mapper.Map<ProductForCreationVm>(product);

            return productForCreation;
        }


        public void DeleteProduct(int productId)
        {
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
            File.Delete(product.ImagePath);
            product.ImagePath = null;
            _productRepository.UpdateProduct(product);
        }
        public void AddNewImageToProduct(IFormFile image, int productId)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Images\\");
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists)
            {
                Directory.CreateDirectory(basePath);
            }
            var fileName = Path.GetFileNameWithoutExtension(image.FileName);
            var filePath = Path.Combine(basePath, image.FileName);

            if (!File.Exists(filePath))
            {
                using var stream = new FileStream(filePath, FileMode.Create);
                image.CopyToAsync(stream);
            }
            _productRepository.AddNewImageToProduct(fileName, productId);
        }
        private  ProductForCreationVm AddImageToNewProduct(ProductForCreationVm newProduct)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Images\\");
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists)
            {
                Directory.CreateDirectory(basePath);
            }
            var fileName = Path.GetFileNameWithoutExtension(newProduct.File.FileName);
            var filePath = Path.Combine(basePath, (newProduct.File.FileName));

            if (!File.Exists(filePath))
            {
                using var stream = new FileStream(filePath, FileMode.Create);
                {
                    newProduct.File.CopyToAsync(stream);
                }
            }
            newProduct.ImagePath = filePath;
            return newProduct;
        }

        public ProductForViewVm GetProductForViewById(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            ProductForViewVm productForView = _mapper.Map<ProductForViewVm>(product);

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
                .GetAllProductDietInfo(productId).FirstOrDefault(x => x.DietInfoTagId == dietInfoId);
            _productRepository.RemoveDietInfoFromProduct(productDietInfoTagToBeRemoved);
        }

        public ProductForCreationVm GetProductForCreation()
        {
            return new ProductForCreationVm()
            {
                AllAllergens = _productRepository.GetAllAllergens().ProjectTo<AllergenForViewVm>(_mapper.ConfigurationProvider).ToList(),
                AllIngredients = _productRepository.GetAllIngredients().Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name,
                }).ToList(),
                AllDietInfoForViewVms = _productRepository.GetAllDietInfo().ProjectTo<DietInfoForViewVm>(_mapper.ConfigurationProvider).ToList()
            };
        }
    }
}
