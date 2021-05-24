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
        ListOfOrdersVm GetAllOrders();
        
        ListOfProductsVm GetAllProducts(int orderId);

        void AddProductToOrder(int orderId, int productId);
        void RemoveProduct(int productId, int orderId);
    }
}
