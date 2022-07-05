using CafeMVC.Application.ViewModels.Orders;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface ICartService
    {
        OrderForCreationVm GetProductForCart(ISession session);
        void AddProductToCart(int quantity, int productId, ISession session);
        void UpdateCartProduct(int quantity, int productId, ISession session);
        void RemoveProductFromCart(int productId, ISession session);
    }
}
