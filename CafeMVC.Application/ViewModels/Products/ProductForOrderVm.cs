using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using AutoMapper.Configuration.Annotations;


namespace CafeMVC.Application.ViewModels.Products
{
    [AutoMap(typeof(CafeMVC.Domain.Model.OrderedProductDetails))]
    public class ProductForOrderVm : IMapFrom<CafeMVC.Domain.Model.OrderedProductDetails>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal BasePrice { get; set; }

        public decimal Discount { get; set; }

        public decimal OverallPrice { get; set; }

        public int ProductId { get; set; }

        [Ignore]
        public ProductForViewVm ProductVm { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<ProductForOrderVm, CafeMVC.Domain.Model.OrderedProductDetails>();
                
        }
    }
}
