using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CafeMVC.Application.Interfaces
{
    public interface ICartService
    {

        void AddProductToCart(int quantity, int productId, ISession session);

        void UpdateCartProduct(int quantity, int productId, ISession session);

        void RemoveProductFromCart(int productId, ISession session);

        List<ProductForOrderVm> GetListOfCartProducts(ISession session);

        decimal GetTotalPrice(ISession session);

        OrderForCreationVm GetOrderFromCart(bool isCollection, int paymentTypeId, ISession session);

        OrderForCreationVm UpdateOrdertForCheckout(OrderForCreationVm newOrder, ISession session);

        CustomerForCreationVm GetCustomerInfo(ISession session);

        List<ContactInfoForCreationVm> GetContactDetails(ISession session);

        List<AddressForCreationVm> GetAddresses(ISession session);
        void ClearSession(ISession session);
    }
}
