using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Products
{
    public class DietInfoTagVm : IMapFrom<CafeMVC.Domain.Model.DietInfoTag>
    {
        public string TagName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.DietInfoTag, DietInfoTagVm>();
        }
    }
}
