using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class ProductsCountResolver : IValueResolver<Order, OrderForUserListVm, int>
    {
        public int Resolve(Order source, OrderForUserListVm destination, int destMember, AutoMapper.ResolutionContext context)
        {
            return source.OrderedProductsDetails.ToList().Count;
        }
    }
}
