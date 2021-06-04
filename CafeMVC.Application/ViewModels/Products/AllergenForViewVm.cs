using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Products
{
    public class AllergenForViewVm : IMapFrom<CafeMVC.Domain.Model.Allergen>
    {
        int Id { get; set; }

        string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Allergen, AllergenForViewVm>();
        }
    }
}