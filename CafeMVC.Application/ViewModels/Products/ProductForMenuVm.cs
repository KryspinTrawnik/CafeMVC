using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForMenuVm : IMapFrom<CafeMVC.Domain.Model.Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public List<IngredientForViewVm> Ingredients { get; set; }

        public DietInfoForViewVm DietInformation { get; set; }

        public List <AllergenForViewVm> Allergens { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Product, ProductForMenuVm>();
        }
    }
}