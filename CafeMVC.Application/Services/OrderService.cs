using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Services
{
    public class OrderService : IOrderService
    {
        public void AddAnnotation(int orderId, string annotation)
        {
            throw new NotImplementedException();
        }

        public int AddOrder(OrderForSummaryVm orderForView)
        {
            throw new NotImplementedException();
        }

        public void AddProductToOrder(int orderId, int productId)
        {
            throw new NotImplementedException();
        }

        public void CanceleOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void ChangeAnnotation(int orderId, string annotation)
        {
            throw new NotImplementedException();
        }

        public void ChangeDeliveryTime(int orderId, string deliveryAddress)
        {
            throw new NotImplementedException();
        }

        public void ChangeLeadTime(int orderId, DateTime leadTimeOfOrder)
        {
            throw new NotImplementedException();
        }

        public void CloseOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public ListOfOrdersVm GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public ListOfProductsVm GetAllProducts(int orderId)
        {
            throw new NotImplementedException();
        }

        public ListOfOrdersVm GetOpenOrders()
        {
            throw new NotImplementedException();
        }

        public OrderForSummaryVm GetOrderbyId(int orderId)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(int productId, int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
