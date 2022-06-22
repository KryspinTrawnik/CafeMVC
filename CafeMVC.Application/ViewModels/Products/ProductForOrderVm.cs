using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForOrderVm : IMapFrom<CafeMVC.Domain.Model.OrderedProductDetails>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public decimal Discount { get; set; }

        public double OverallPrice { get; set; }

        public ProductForListVm Product { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.OrderedProductDetails, ProductForOrderVm>().ReverseMap();
        }
    }
}
