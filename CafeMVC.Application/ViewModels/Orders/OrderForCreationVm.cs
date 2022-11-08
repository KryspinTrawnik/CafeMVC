using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.ViewModels.Orders
{
    [AutoMap(typeof(CafeMVC.Domain.Model.Order))]
    public class OrderForCreationVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public DateTime LeadTime { get; set; }
       
        public DateTime DateOfOrder { get; set; }
       
        public decimal TotalPrice { get; set; }

        public decimal DeliveryCharge{ get; set; }

        public string Note { get; set; }

        public string OrderConfirmation { get; set; }

        public bool IsCollection { get; set; } = true;

        public int CustomerId { get; set; }

        public CustomerForCreationVm Customer { get; set; }
        
        public PaymentForCreationVm Payment { get; set; }

        public StatusForCreationVm Status { get; set; }
        [Ignore]
        public List<AddressForCreationVm> Addresses { get; set; }

        [Ignore]
        public List<ContactInfoForCreationVm> ContactDetails { get; set; }

        public List<ProductForOrderForCreationVm> Products { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForCreationVm>().ReverseMap()
                .ForMember(d => d.OrderedProductsDetails, s => s.MapFrom(opt => opt.Products));
        }

    }

    public class OrderForCreationValidator : AbstractValidator<OrderForCreationVm>
    {
        public OrderForCreationValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleForEach(x => x.Addresses).SetValidator(new AddressForCreationValidator());
        }

    }
    
}
