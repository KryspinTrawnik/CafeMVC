﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public void AddOrChangeNote(int orderId, string note)
        {
            _orderRepository.AddOrChangeNote(orderId, note);
        }

        public string AddOrder(OrderForCreationVm order)
        {
            Order newOrder = _mapper.Map<Order>(order);
            int orderId = _orderRepository.AddNewOrder(newOrder);
            string orderConfirmation = GenerateOrderConfrimation(orderId);
            newOrder.OrderConfirmation = orderConfirmation;
            

            return orderConfirmation;
        }
        private string GenerateOrderConfrimation(int orderId)
        {
            string todayDate = DateTime.Now.ToString("MMddyy");
            string orderConfirmation = $"Order-{orderId}{todayDate}";

            return orderConfirmation;
        }

        public void AddProductToOrder(int orderId, int productId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            order.Products.Add(_productRepository.GetProductById(orderId));
            _orderRepository.UpdateOrder(order);
        }

        public void CanceleOrder(int orderId)
        {
            _orderRepository.DeleteItem(orderId);
        }

        public void ChangeDeliveryAddress(int orderId, AddressForCreationVm newDeliveryAddress)
        {
            Order order = _orderRepository.GetItemById(orderId);
            order.Addresses.Remove(order.Addresses.Find(x => x.AddressType.Id == 2));
            Address address = _mapper.Map<Address>(newDeliveryAddress);
            order.Addresses.Add(address);
            _orderRepository.UpdateItem(order);
        }

        public void ChangeLeadTime(int orderId, DateTime newLeadTimeOfOrder)
        {
            Order order = _orderRepository.GetItemById(orderId);
            order.LeadTime = newLeadTimeOfOrder;
            _orderRepository.UpdateItem(order);
        }

        public void CloseOrder(int orderId)
        {
            Order order = _orderRepository.GetItemById(orderId);
            order.HasBeenDone = true;
            _orderRepository.UpdateItem(order);
        }

        public ListOfOrdersVm GetOrdersToDisplay(int pageSize, int pageNo, string searchString)
        {
            List<OrderForListVm> orderForListVm = _orderRepository.GetAllType()
                .ProjectTo<OrderForListVm>(_mapper.ConfigurationProvider).ToList();
            List<OrderForListVm> ordersToDisplay = orderForListVm.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListOfOrdersVm listOfOrdersVm = new()
            {
                PageSize= pageSize,
                CurrentPage =pageNo,
                SearchString = searchString,
                ListOfOrders = ordersToDisplay,
                Count = orderForListVm.Count
            };
            return listOfOrdersVm;
        }

        public ListOfProductsVm GetAllProducts(int orderId)
        {
            List<ProductForListVm> productForListVm = _orderRepository.GetAllProductsFromOrder(orderId)
                 .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList();

            ListOfProductsVm listOfProductsVm = new()
            {
                ListOfAllProducts = productForListVm,
                Count = productForListVm.Count
            };
            return listOfProductsVm;
        }

        public ListOfOrdersVm GetAllOpenOrders()
        {
            List<OrderForListVm> ordersForListVm = _orderRepository.GetAllOpenOrders()
                .ProjectTo<OrderForListVm>(_mapper.ConfigurationProvider).ToList();
            ListOfOrdersVm listOfOrdersVm = new()
            {
                ListOfOrders = ordersForListVm,
                Count = ordersForListVm.Count
            };
            return listOfOrdersVm;
        }

        public OrderForCreationVm GetOrderForCreationVmById(int orderId)
        {
            Order order = _orderRepository.GetItemById(orderId);
            OrderForCreationVm orderForCreationVm = _mapper.Map<OrderForCreationVm>(order);

            return orderForCreationVm;
        }
        public OrderForSummaryVm GetOrderSummaryVmById(int orderId)
        {
            Order order = _orderRepository.GetItemById(orderId);
            OrderForSummaryVm orderForCreationVm = _mapper.Map<OrderForSummaryVm>(order);

            return orderForCreationVm;
        }
        public void RemoveProduct(int productId, int orderId)
        {
            Order order = _orderRepository.GetItemById(orderId);
            order.Products.Remove(_productRepository.GetItemById(orderId));
            _orderRepository.UpdateItem(order);
        }
    }
}
