using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForUserListVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }

        public int ProductsCount { get; set; }

        public decimal TotalPrice { get; set; }
    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForUserListVm>()
                .ForMember(s => s.ProductsCount, opt => opt.MapFrom(d => d.OrderedProductsDetails.Count));
        }

    }
}
                        