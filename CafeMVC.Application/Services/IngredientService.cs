using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class IngredientService :IIngredientService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public IngredientService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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

        void IIngredientService.AddIngredientToProduct(int productId, int ingredientId)
        {
            throw new System.NotImplementedException();
        }
    }
}
