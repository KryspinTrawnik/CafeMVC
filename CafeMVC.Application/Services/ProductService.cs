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
        private const string _imageDirecotry = "Images";

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public void AddNewProduct(ProductForCreationVm product)
        {
            Product newProduct = _mapper.Map<Product>(product);
            _productRepository.AddNewProduct(newProduct);

        }

        public ProductForCreationVm GetProductForCreationById(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            ProductForCreationVm productForCreation = _mapper.Map<ProductForCreationVm>(product);
            return productForCreation;
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        // metode jaką tą widzę chyba trzeci albo czwarty raz, moze warto by bylo wyprowadzic z tego repo IBaseRepository ktory
        // bedzie mial metode 'GetAll' i uzywac tej samej metody za kazdym razem?
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
            // stringi jak "Images" najlepiej wrzucic do jakiejs klasy Consts albo do zmiennych lokalnych. 
            // ja dla ulatwienia zrobie to drugie. Ladnie, ze uzywasz path combine ale zrobiles to zle
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), _imageDirecotry);
            
            // klamry, to nie python
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            // nie podoba mi sie trzymanie plików na serwerze, tak się nie robi od kilku ładnych lat. Poczytaj sobie o 
            // Azure Blob Storage albo Minio. 
            var fileName = Path.GetFileNameWithoutExtension(image.FileName);
            var filePath = Path.Combine(basePath, image.FileName);

            if (!File.Exists(filePath))
            {
                using var stream = new FileStream(filePath, FileMode.Create);
                image.CopyToAsync(stream);
            }

            _productRepository.AddNewImageToProduct(fileName, productId);
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

        public void AddIngredientToProduct(int productId, int ingredientId)
        {
            Product product = _productRepository.GetProductById(productId);
            Ingredient ingredient = _productRepository.GetIngredientById(ingredientId);
            product.ProductIngredients.Add(new ProductIngredient
            {
                Ingredient = ingredient,
                IngredientId = ingredientId,
                Product = product,
                ProductId = productId
            });
            _productRepository.UpdateProduct(product);
        }
        public void AddNewIngredient(IngredientForCreationVm ingredient)
        {
            Ingredient newIngredient = _mapper.Map<Ingredient>(ingredient);
            _productRepository.AddNewIngredient(newIngredient);

        }

        public void DeleteIngredient(int productId, int ingredientId)
        {
            Product product = _productRepository.GetProductById(productId);
            product.ProductIngredients.Remove(product.ProductIngredients.FirstOrDefault(x => x.IngredientId == ingredientId));
        }

        // znowu prawie identyczna metoda. Da się to napisać raz, by nie powtarzać tego samego kodu setki razy ;/
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

        // nie musisz tego opisywac w komentarzach ;) Widac, co robi ta metoda
        public void AddNewAllergen(AllergenForViewVm allergen)
        {
            Allergen newAllergen = _mapper.Map<Allergen>(allergen);

            _productRepository.AddNewAllergen(newAllergen);

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

        public void AddAllergenToProduct(int productId, int allergenId)
        {
            Product product = _productRepository.GetProductById(productId);
            Allergen allergen = _productRepository.GetAllergenById(allergenId);
            _productRepository.AddAllergenToProduct(new ProductAllergen
            {
                Allergen = allergen,
                AllergenId = allergenId,
                Product = product,
                ProductId = productId
            });
        }
    }
}
