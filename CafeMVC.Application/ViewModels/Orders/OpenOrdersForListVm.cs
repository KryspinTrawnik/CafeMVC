using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OpenOrdersForListVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }

        public DateTime LeadTime { get; set; }

        public int NumberOfProduct { get; set; }

        public bool IsCollection { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OpenOrdersForListVm>()
                .ForMember(s => s.NumberOfProduct, opt => opt.MapFrom(d => d.OrderedProductsDetails.Count));

        }
    }
}
