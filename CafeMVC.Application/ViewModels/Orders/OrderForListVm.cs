using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForListVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }

        public DateTime LeadTime { get; set; }

        public int NumberOfProduct { get; set; }

        public bool IsCollection { get; set; }

        public string StatusName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForListVm>()
                .ForPath(d => d.StatusName, opt => opt.MapFrom(s => s.Status.Name))
                .ForPath(d => d.NumberOfProduct, opt => opt.MapFrom(s => s.OrderedProductsDetails.Count));
        }
    }
}
