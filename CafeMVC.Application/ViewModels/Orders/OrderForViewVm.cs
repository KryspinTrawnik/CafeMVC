using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForViewVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public double TotalPrice { get; set; }

        public List<ProductForListVm> Products { get; set; }

        public DateTime DateOfOrder { get; set; }

        public AddressForOrderViewVm DeliveryAddress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForViewVm>()
                .ForMember(s => s.CustomerName, opt => opt.MapFrom(d => d.Customer.FirstName + " " + d.Customer.Surname));
        }

    }
}
