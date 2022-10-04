using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForOrderSummaryVm : IMapFrom<CafeMVC.Domain.Model.OrderedProductDetails>
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal OverallPrice { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.OrderedProductDetails, ProductForOrderSummaryVm>()
                .ForPath(d => d.Name, opt => opt.MapFrom(s => s.Product.Name));

        }
    }
}
