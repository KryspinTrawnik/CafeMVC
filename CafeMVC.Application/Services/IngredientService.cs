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

       
        public void AddNewIngredient(IngredientForViewVm ingredient)
        {
            Ingredient newIngredient = _mapper.Map<Ingredient>(ingredient);
            _productRepository.AddNewIngredient(newIngredient);

        }

        public void DeleteIngredient(int productId, int ingredientId)
        {
            Product product = _productRepository.GetProductById(productId);
            product.ProductIngredients.Remove(product.ProductIngredients.FirstOrDefault(x => x.IngredientId == ingredientId));
        }


        public List<IngredientForViewVm> GetAllIngredients() => _productRepository.GetAllIngredients()
                  .ProjectTo<IngredientForViewVm>(_mapper.ConfigurationProvider).ToList();
         
        void IIngredientService.AddIngredientToProduct(int productId, int ingredientId)
        {
            throw new System.NotImplementedException();
        }

        public List<IngredientForViewVm> GetProductAllIngredients(int productId)
        => _productRepository.GetAllProductIngredients(productId).Select(x => x.Ingredient)
            .ProjectTo<IngredientForViewVm>(_mapper.ConfigurationProvider).ToList();

        public void UpdateProductIngredientTable(int productId, List<ProductIngredient> productIngredients)
        {
            var list = _productRepository.GetAllProductIngredients(productId).ToList();
            List<ProductIngredient> toBeRemoved = list.Except(productIngredients, new Helper()).ToList();
            if (toBeRemoved != null)
            {
                for (int i = 0; i < toBeRemoved.Count; i++)
                {
                    _productRepository.RemoveIngredientFromProduct(toBeRemoved[i]);
                }
            }
            List<ProductIngredient> toBeAdded = productIngredients
                .Except(_productRepository.GetAllProductIngredients(productId), new Helper()).ToList();
            if (toBeAdded != null)
            {
                for (int i = 0; i < toBeAdded.Count; i++)
                {
                    toBeAdded[i].ProductId = productId;
                    _productRepository.AddIngredientToProduct(toBeAdded[i]);
                }
            }
        }
    }
}
