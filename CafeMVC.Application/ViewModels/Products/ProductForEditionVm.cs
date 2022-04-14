using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{

    public class ProductForEditionVm : ProductForCreationVm, IMapFrom<CafeMVC.Domain.Model.Product> 
    {
        public List<IngredientForViewVm> AllIngredients { get; set; }

        public List<AllergenForViewVm> AllAllergens { get; set; }

        public List<DietInfoForViewVm> AllDietInfoForViewVms { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Product, ProductForEditionVm>().ReverseMap();
        }

    }
}
