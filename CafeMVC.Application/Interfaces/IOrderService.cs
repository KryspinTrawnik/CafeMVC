using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using System;

namespace CafeMVC.Application.Interfaces
{
    public interface IOrderService
    {
        ListOfOrdersVm GetOrdersToDisplay(int pageSize, int pageNo, string searchString);

        ListOfProductsVm GetAllProducts(int orderId);

        void RemoveProduct(int productId, int orderId);

        OrderForCreationVm GetOrderForCreationVmById(int orderId);

        int AddOrder(OrderForCreationVm orderForView, ISession session);

        void ChangeLeadTime(int orderId, DateTime leadTimeOfOrder);

        void AddOrChangeNote(int orderId, string annotation);

        ListOfOrdersVm GetAllOpenOrders();

        OrderForSummaryVm GetOrderSummaryVmById(int orderId);

        void ChangeOrderStatus(int orderId, int statusId);

        OrderForViewVm GetOrderToView(int orderId);

        OrderForCreationVm GetOrderForCart(ISession session);

        OrderForCreationVm AssignAddressesTypes(OrderForCreationVm newOrder);
    }
}
