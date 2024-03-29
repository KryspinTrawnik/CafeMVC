﻿using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class PaymentTypeForCreationVm :IMapFrom<CafeMVC.Domain.Model.Payment>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaymentTypeForCreationVm, CafeMVC.Domain.Model.PaymentType>().ReverseMap();

        }
    }
}