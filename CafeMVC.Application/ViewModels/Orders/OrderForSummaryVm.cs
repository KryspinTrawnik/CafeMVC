using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForSummaryVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Note { get; set; }

        public string OrderConfirmation { get; set; }

        public DateTime LeadTime { get; set; }

        public bool IsCollection { get; set; }

        public AddressForSummaryVm DeliveryAddress { get; set; }

        public List<ProductForOrderSummaryVm> Products { get; set; }

        public List<CustomerContactInfoForViewVm> ContactDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForSummaryVm>()
                .ForPath(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.FirstName +" " + s.Customer.Surname));

        }
    }
}
