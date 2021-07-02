using AutoMapper;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public void AddOrChangeNote(int orderId, string note)
        {
            _orderRepository.ChangeNote(orderId, note);
        }

        public string AddOrder(OrderForCreationVm order)
        {
            var newOrder = _mapper.Map<Order>(order);
            string orderConfirmation = GenerateOrderConfrimation();
            newOrder.OrderConfirmation = orderConfirmation;
            _orderRepository.AddItem(newOrder);
      
            return orderConfirmation;
        }
        private string GenerateOrderConfrimation()
        {
            string todayDate = DateTime.Now.ToString("MM/dd/yy").RemoveSpecialCharacters();
            string orderConfirmation = $"Order-{_orderRepository.GetAllType().Count()}{todayDate}";

            return orderConfirmation;
        }

        public void AddProductToOrder(int orderId, int productId)
        {
            throw new NotImplementedException();
        }

        public void CanceleOrder(int orderId)
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

        public OrderForCreationVm GetOrderbyId(int orderId)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(int productId, int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
