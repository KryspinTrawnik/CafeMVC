using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Products
{
    public class IngredientForCreationVm : IMapFrom<CafeMVC.Domain.Model.Ingredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Ingredient, IngredientForCreationVm>().ReverseMap();
        }
    }
}
