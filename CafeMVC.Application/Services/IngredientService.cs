using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Helpers;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.Services.Helpers;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class IngredientService : IIngredientService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public IngredientService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddNewIngredient(IngredientForViewVm ingredient)
        {
            Ingredient newIngredient = _mapper.Map<Ingredient>(ingredient);
            _productRepository.AddNewIngredient(newIngredient);

        }

        public void DeleteIngredient(int ingredientId)
        {
            _productRepository.DeleteIngredient(ingredientId);

        }

        public List<IngredientForViewVm> GetAllIngredients() => _productRepository.GetAllIngredients()
                  .ProjectTo<IngredientForViewVm>(_mapper.ConfigurationProvider).ToList();

        public List<IngredientForViewVm> GetProductAllIngredients(int productId)
        => _productRepository.GetAllProductIngredients(productId).Select(x => x.Ingredient)
            .ProjectTo<IngredientForViewVm>(_mapper.ConfigurationProvider).ToList();

        public void UpdateProductIngredientTable(int productId, List<ProductIngredient> productIngredients)
        {
            List<ProductIngredient> allProductIngredient = _productRepository.GetAllProductIngredients(productId).ToList();
            List<ProductIngredient> toBeRemoved = allProductIngredient.Except(productIngredients, new IngredientComparerHelper()).ToList();
            if (toBeRemoved != null)
            {
                for (int i = 0; i < toBeRemoved.Count; i++)
                {
                    _productRepository.RemoveIngredientFromProduct(toBeRemoved[i]);
                }
            }
            List<ProductIngredient> toBeAdded = productIngredients
                .Except(_productRepository.GetAllProductIngredients(productId), new IngredientComparerHelper()).ToList();
            if (toBeAdded != null)
            {
                for (int i = 0; i < toBeAdded.Count; i++)
                {
                    toBeAdded[i].ProductId = productId;
                    _productRepository.AddIngredientToProduct(toBeAdded[i]);
                }
            }
        }

        public ListOfIngredientsVm GetListIngredientsForEdition(int pageSize, int pageNo, string searchString)
        {
            List<IngredientForViewVm> allIngredients = _productRepository.GetAllIngredients().Where(x => x.Name.StartsWith(searchString))
                .ProjectTo<IngredientForViewVm>(_mapper.ConfigurationProvider).ToList();
            List<IngredientForViewVm> ingredientsToDisplay = allIngredients.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListOfIngredientsVm listOfAllIngredients = new()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Ingredients = ingredientsToDisplay,
                Count = allIngredients.Count
            };

            return listOfAllIngredients;
        }
    }
}
