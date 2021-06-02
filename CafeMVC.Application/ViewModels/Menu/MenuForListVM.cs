using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;
using System.ComponentModel;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class MenuForListVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, MenuForCreationVm>();

        }
    }
   

}
