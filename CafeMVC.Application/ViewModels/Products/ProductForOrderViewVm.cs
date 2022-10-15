using AutoMapper.Configuration.Annotations;
using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForOrderViewVm : IMapFrom<Domain.Model.OrderedProductDetails>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal BasePrice { get; set; }

        public decimal Discount { get; set; }

        public decimal OverallPrice { get; set; }

        public int ProductId { get; set; }

        public ProductForViewVm Product { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.OrderedProductDetails, ProductForOrderViewVm>();

        }
    }
}
