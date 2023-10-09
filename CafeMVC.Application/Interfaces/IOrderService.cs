using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface IOrderService
    {
        ListOfProductsVm GetAllProducts(int orderId);

        void RemoveProduct(int productId, int orderId);

        int AddOrder(OrderForCreationVm orderForView, ISession session);

        void ChangeLeadTime(int orderId, DateTime leadTimeOfOrder);

        OrderForSummaryVm GetOrderSummaryVmById(int orderId);

        void ChangeOrderStatus(int orderId, int statusId);

        OrderForViewVm GetOrderToView(int orderId);

        OrderForCreationVm GetOrderForCart(ISession session);

        OrderForCreationVm AssignAddressesTypes(OrderForCreationVm newOrder);

        ListsOfOrdersForIndexVm GetOrdersForIndex();

        AdminDashboardVm GetDashboardVm();
        Task<List<OrderForUserListVm>> GetCustomerOrders(int customerId);
    }
}
