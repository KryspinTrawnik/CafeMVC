using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForListVm : IMapFrom<CafeMVC.Domain.Model.Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Product, ProductForListVm>();
        }
    }
}
