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

        public string StatusName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForUserListVm>()
                .ForPath(d => d.StatusName, opt => opt.MapFrom(s => s.Status.Name))
                .ForMember(d => d.ProductsCount, opt => opt.MapFrom(new ProductsCountResolver().Resolve));
        }

    }
}
                        