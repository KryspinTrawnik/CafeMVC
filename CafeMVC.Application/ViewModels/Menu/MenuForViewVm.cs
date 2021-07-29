using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Menu;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class MenuForViewVm : IMapFrom<Domain.Model.Menu>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductForViewVm> Products { get; set; }
        
        public int Count { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Menu, MenuForViewVm>();

        }
    }

}
