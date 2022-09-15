using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.Services.Helpers;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForCreationVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public string LeadTime { get; set; }
       
        public DateTime DateOfOrder { get; set; }
       
        public decimal TotalPrice { get; set; }

        public string Note { get; set; }

        public string OrderConfirmation { get; set; }

        public bool IsCollection { get; set; } = true;

        public int CustomerId { get; set; }

        public CustomerForCreationVm Customer { get; set; }
        
        public PaymentForCreationVm Payment { get; set; }

        public StatusForCreationVm Status { get; set; }

        public List<AddressForCreationVm> Addresses { get; set; }

        public List<ContactInfoForCreationVm> ContactDetails { get; set; }

        public List<ProductForOrderVm> Products { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForCreationVm>().ReverseMap()
              .ForMember(s => s.LeadTime, opt =>
              {
                  opt.MapFrom(x => new Helper().ConvertStringToDateTime(LeadTime)) ;

              });

        }

    }
}
