using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Products
{
    public class AllergenForViewVm : IMapFrom<CafeMVC.Domain.Model.Allergen>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Btn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Allergen, AllergenForViewVm>().ReverseMap();
        }
    }
}