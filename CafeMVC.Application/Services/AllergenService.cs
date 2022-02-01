using AutoMapper;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;

namespace CafeMVC.Application.Services
{
    public class AllergenService : IAllergenService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AllergenService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddNewAllergen(AllergenForViewVm allergen)
        {
            Allergen newAllergen = _mapper.Map<Allergen>(allergen);

            _productRepository.AddNewAllergen(newAllergen);

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

        void IAllergenService.deleteAllergen(int allergenId)
        {
            throw new NotImplementedException();
        }

        void IAllergenService.DeleteAllergenFromProduct(int productId, int allergenId)
        {
            throw new NotImplementedException();
        }
    }
}
