
using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForCreationVm : IMapFrom<CafeMVC.Domain.Model.Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImagePath  { get; set; }
        
        public List<IngredientForViewVm> Ingredients { get; set; }
        
        public List<AllergenForViewVm> Allergens { get; set; }
        
        public List<DietInfoForViewVm> DietInfoForViewVms { get; set; }

        public IFormFile File { get; set; }
            
        public string PriceString { get; set; }

        public List<int> IngredientsIds { get; set; }

        public List<int> AllergensIds { get; set; }

        public List<int> DietInfoIds { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Product, ProductForCreationVm>().ReverseMap();
        }
    
    }
}
