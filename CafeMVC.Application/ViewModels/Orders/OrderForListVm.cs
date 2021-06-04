﻿using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForListVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }

        public string CustomerName { get; set; }

        public double TotalPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForListVm>()
                .IncludeMembers(s => s.Customer)
                .ForMember(s => s.CustomerName, opt => opt.MapFrom(d => d.Customer.FirstName + " " + d.Customer.Surname));

        }

    }
}