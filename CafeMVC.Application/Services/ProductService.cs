using AutoMapper;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
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

        public bool AddNewAllergen(AllergenForViewVm allergen)
        {
            Allergen newAllergen = _mapper.Map<Allergen>(allergen);
            bool IsAllergenAlreadyExist = _productRepository.GetAllAllergens().Any(x => x.Name == newAllergen.Name);
            if (IsAllergenAlreadyExist == false)
            {
                _productRepository.AddNewAllergen(newAllergen);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddNewImageToProduct(byte image, int productId)
        {
            throw new NotImplementedException();
        }

        public bool AddNewIngredient(IngredientForViewVm ingredient)
        {
            throw new NotImplementedException();
        }

        public bool AddNewProduct(ProductForCreationVm product)
        {
            throw new NotImplementedException();
        }

        public void AddNewTagToDietInformation(string imageName, int dietInfoId)
        {
            throw new NotImplementedException();
        }

        public void ChangeDietInformation(int productId, DietInfoForViewVm dietInformation)
        {
            throw new NotImplementedException();
        }

        public void DeleteImageFromProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void DeleteIngredient(int productId, int ingredientId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTagFromDietInformation(int tagId, int dietInfoId)
        {
            throw new NotImplementedException();
        }

        public ListOfIngredientsVm GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public ListOfProductsVm GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductForViewVm GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public ProductForViewVm GetProductDetails(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductForViewVm productModel)
        {
            throw new NotImplementedException();
        }
    }
}
