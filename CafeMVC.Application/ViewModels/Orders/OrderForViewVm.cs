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

        public decimal TotalPrice { get; set; }

        public decimal DeliveryCharge { get; set; }

        public bool IsCollection { get; set; }

        public string OrderConfirmation { get; set; }

        public List<ProductForOrderViewVm> Products { get; set; }

        public DateTime DateOfOrder { get; set; }

        public DateTime LeadTime { get; set; }

        public PaymentForOrderViewVm Payment { get; set; }
      

        public string Note { get; set; }

        public string Status { get; set; }

        public AddressForSummaryVm DeliveryAddress { get; set; }

        public List<StatusForCreationVm> AllStatuses { get; set; }

        public List<CustomerContactInfoForViewVm> ContactDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForViewVm>()
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.FirstName + " " + s.Customer.Surname))
                .ForPath(d => d.Status, opt => opt.MapFrom(s => s.Status.Name));
        }

    }
}
