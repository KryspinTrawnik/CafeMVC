using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForSummaryVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public double TotalPrice { get; set; }

        public List<ProductForListVm> Products { get; set; }

        public AddressForOrderSummaryVm DeliveryAddress { get; set; }

        public AddressForOrderSummaryVm BillingAddress { get; set; }

        public DateTime LeadTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForSummaryVm>();
        }

    }
}
