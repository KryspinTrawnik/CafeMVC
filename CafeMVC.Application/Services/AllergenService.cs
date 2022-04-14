using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void DeleteAllergen(int allergenId)
        {
            throw new NotImplementedException();
        }

        public List<AllergenForViewVm> GetAllAllergens() => _productRepository.GetAllAllergens()
        .ProjectTo<AllergenForViewVm>(_mapper.ConfigurationProvider).ToList();

        public List<AllergenForViewVm> GetAllProductAllergens(int productId)
        => _productRepository.GetAllAllergensFromProduct(productId).Select(x => x.Allergen)
            .ProjectTo<AllergenForViewVm>(_mapper.ConfigurationProvider).ToList();

        public void UpdateProductAllergenTable(int productId, List<ProductAllergen> productAllergens)
        {
            List<ProductAllergen> allProductAllergens = _productRepository.GetAllAllergensFromProduct(productId).ToList();
            List<ProductAllergen> toBeRemoved = allProductAllergens.Except(productAllergens, new Helper()).ToList();
            if (toBeRemoved != null)
            {
                for (int i = 0; i < toBeRemoved.Count; i++)
                {
                    _productRepository.RemoveAllergenFromProduct(toBeRemoved[i]);
                }
            }
            List<ProductAllergen> toBeAdded = productAllergens
                .Except(_productRepository.GetAllAllergensFromProduct(productId), new Helper()).ToList();
            if (toBeAdded != null)
            {
                for (int i = 0; i < toBeAdded.Count; i++)
                {
                    toBeAdded[i].ProductId = productId;
                    _productRepository.AddAllergenToProduct(toBeAdded[i]);
                }
            }
        }
    }
}