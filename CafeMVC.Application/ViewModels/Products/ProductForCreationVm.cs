using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForCreationVm : IMapFrom<CafeMVC.Domain.Model.Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public List<IngredientForViewVm> Ingredients { get; set; }

        public List<AllergenForViewVm> Allergens { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Product, ProductForCreationVm>().ReverseMap();
        }
    
    }
}
