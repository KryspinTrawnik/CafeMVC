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
    public class OrderForCreationVm : IMapFrom<CafeMVC.Domain.Model.Order>
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public int OrderConfirmation { get; set; }

        public bool IsCollection { get; set; }

        public int CustomerId { get; set; }

        public List <AddressForCreationVm> Addresses { get; set; }

        public List<ProductForMenuVm> Products { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Order, OrderForCreationVm>();

        }

    }
}
