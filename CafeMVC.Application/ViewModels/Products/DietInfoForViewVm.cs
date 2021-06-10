using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{
    public class DietInfoForViewVm : IMapFrom<CafeMVC.Domain.Model.DietInformation>
    {   
        public List<DietInfoTagVm> ListOfTagName { get; set; }
            
    }
}