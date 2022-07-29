using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CafeMVC.Application.Interfaces
{
    public interface ICartService
    {
        OrderForCreationVm GetProductForCart(ISession session);

        void AddProductToCart(int quantity, int productId, ISession session);

        void UpdateCartProduct(int quantity, int productId, ISession session);

        void RemoveProductFromCart(int productId, ISession session);

        List<ProductForOrderVm> GetListOfCartProducts(ISession session);
    }
}
