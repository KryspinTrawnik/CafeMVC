using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class MenuForCreationVm : IMapFrom<CafeMVC.Domain.Model.Menu>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<ProductForListVm> MenuProducts { get; set; }

        public ListOfProductsVm AllProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Menu, MenuForCreationVm>().ReverseMap();

        }
        
    }
}
