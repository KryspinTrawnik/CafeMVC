using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using CafeMVC.Application.Helpers;

namespace CafeMVC.Application.Services
{
    public class OrderService : IOrderService
    {   

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerService _customerService;
        private readonly ICartService _cartService;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository, ICustomerService customerService, ICartService cartService )
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _productRepository = productRepository;
            _customerService = customerService;
            _cartService = cartService;
        }

        private string GenerateOrderConfrimation(int orderId)
        {
            string todayDate = DateTime.UtcNow.ToString("MMddyy");
            string orderConfirmation = $"Order-{orderId}{todayDate}";

            return orderConfirmation;
        }
        public void AddOrChangeNote(int orderId, string note) => _orderRepository.AddOrChangeNote(orderId, note);

        public int AddOrder(OrderForCreationVm order, ISession session)
        {
            order.Products = _cartService.GetListOfCartProducts(session);
            order.DateOfOrder = DateTime.Now;
            Order newOrder = _mapper.Map<Order>(order);
            int orderId = _orderRepository.AddNewOrder(newOrder);
            string orderConfirmation = GenerateOrderConfrimation(orderId);
            newOrder.OrderConfirmation = orderConfirmation;
            _orderRepository.UpdateOrder(newOrder);

            return orderId;
        }

       
        public void ChangeLeadTime(int orderId, DateTime newLeadTimeOfOrder)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            order.LeadTime = newLeadTimeOfOrder;
            _orderRepository.UpdateOrder(order);
        }

        public ListOfOrdersVm GetOrdersToDisplay(int pageSize, int pageNo, string searchString)
        {
            List<OrderForListVm> orderForListVm = _orderRepository.GetAllOrders()
                .ProjectTo<OrderForListVm>(_mapper.ConfigurationProvider).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            return new()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                ListOfOrders = orderForListVm,
                Count = orderForListVm.Count
            };
        }

        public ListOfProductsVm GetAllProducts(int orderId)
        {
            List<ProductForListVm> productForListVm = _orderRepository.GetAllProductsFromOrder(orderId)
                 .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList();

            return new()
            {
                ListOfAllProducts = productForListVm,
                Count = productForListVm.Count
            };
        }
        public ListOfOrdersVm GetAllOpenOrders()
        {
            List<OrderForListVm> ordersForListVm = _orderRepository.GetAllOpenOrders()
                .ProjectTo<OrderForListVm>(_mapper.ConfigurationProvider).ToList();

            return new()
            {
                ListOfOrders = ordersForListVm,
                Count = ordersForListVm.Count
            };
        }

        public OrderForCreationVm GetOrderForCreationVmById(int orderId) => _mapper.Map<OrderForCreationVm>(_orderRepository.GetOrderById(orderId));

        public OrderForSummaryVm GetOrderSummaryVmById(int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderForSummaryVm orderForCreationVm = _mapper.Map<OrderForSummaryVm>(order);

            return orderForCreationVm;
        }
        public void RemoveProduct(int productId, int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderedProductDetails orderProductTobeRemoved = order.OrderedProductsDetails.FirstOrDefault(x => x.ProductId == productId);
            order.OrderedProductsDetails.Remove(orderProductTobeRemoved);
            _orderRepository.UpdateOrder(order);
        }

        public void ChangeOrderStatus(int orderId, int statusId) => _orderRepository.ChangeStatusOfOrder(orderId, statusId);

        public OrderForViewVm GetOrderToView(int orderId) => _mapper.Map<OrderForViewVm>(_orderRepository.GetOrderById(orderId));

      

        public OrderForCreationVm PrepareOrderForCreation(bool isCollection)
        {
            OrderForCreationVm newOrder = new()
            {
               
            };

            throw new NotImplementedException();
        }
    }

}
