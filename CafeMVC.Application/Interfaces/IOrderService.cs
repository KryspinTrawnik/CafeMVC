using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface IOrderService
    {
        ListOfOrdersVm GetOrdersToDisplay(int pageSize, int pageNo, string searchString);

        ListOfProductsVm GetAllProducts(int orderId);

        void AddProductToOrder(int orderId, int productId);

        void RemoveProduct(int productId, int orderId);

        OrderForCreationVm GetOrderForCreationVmById(int orderId);

        string AddOrder(OrderForCreationVm orderForView);

        void ChangeLeadTime(int orderId, DateTime leadTimeOfOrder);

        void ChangeDeliveryAddress(int orderId, AddressForCreationVm newDeliveryAddress);

        void AddOrChangeNote(int orderId, string annotation);

        void CanceleOrder(int orderId);

        void CloseOrder(int orderId);

        ListOfOrdersVm GetAllOpenOrders();

        OrderForSummaryVm GetOrderSummaryVmById(int orderId);
    }
}
