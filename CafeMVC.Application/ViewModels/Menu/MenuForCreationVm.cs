using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Products;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class MenuForCreationVm : IMapFrom<CafeMVC.Domain.Model.Menu>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<ProductForListVm> Products { get; set; }

        public List<ProductForListVm> AllProducts { get; set; }

        public bool IsItPublic { get; set; }

        public List <int> ProductsIds { get; set; }

        public string Btn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Menu, MenuForCreationVm>().ReverseMap();

        }
        
    }
}
