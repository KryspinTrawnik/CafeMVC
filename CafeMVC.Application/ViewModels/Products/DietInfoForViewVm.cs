using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{
    public class DietInfoForViewVm : IMapFrom<CafeMVC.Domain.Model.DietInformation>
    {   
        public List<byte> Images { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.DietInformation, DietInfoForViewVm>();
        }
    }
}