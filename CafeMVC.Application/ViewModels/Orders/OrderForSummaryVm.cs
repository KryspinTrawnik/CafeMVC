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

        public string Note { get; set; }

        public string OrderConfirmation { get; set; }

        public DateTime LeadTime { get; set; }

        public List<AddressForSummaryVm> Addresses { get; set; }

        public List<ProductForListVm> Products { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForSummaryVm>();

        }
    }
}
