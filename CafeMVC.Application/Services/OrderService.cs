using AutoMapper;
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

        // ogolnie te serwisy są niepotrzebnym couplingiem. Tak jak je przeglądam, wszystko zrobiłbyś patternem repository i tak byłoby ok.
        // wiecej kodu to wiecej godzin by to utrzymac i trudniejszy debug. 

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // to co napisalem wczesniej, powtarzasz drugi raz te sama metode
        public void AddOrChangeNote(int orderId, string note)
            => _orderRepository.AddOrChangeNote(orderId, note);

        public string AddOrder(OrderForCreationVm order)
        {
            Order newOrder = _mapper.Map<Order>(order);
            int orderId = _orderRepository.AddNewOrder(newOrder);
            string orderConfirmation = GenerateOrderConfrimation(orderId);
            newOrder.OrderConfirmation = orderConfirmation;

            return orderConfirmation;
        }

        // method ordering, doczytaj. Publiczne metody powinny byc wyzej niz prywatne
        // order confirm jako data?
        private string GenerateOrderConfrimation(int orderId)
        {
            // uzywaj UtcNow zamiast Now. Now ściąga ci datę serwera (np kompa na ktorym uruchomiles apke), UTC jest universal timem czyli +0:00
            string todayDate = DateTime.UtcNow.ToString("MMddyy");
            string orderConfirmation = $"Order-{orderId}{todayDate}";

            return orderConfirmation;
        }

        public void AddProductToOrder(int orderId, int productId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            if (order is null)
            {
                // logika
            }

            order.OrderProducts.Add(
                new()
                {
                    Order = order,
                    OrderId = orderId,
                    ProductId = productId,
                    Product = _productRepository.GetProductById(productId)
                });

            _orderRepository.UpdateOrder(order);
        }

        public void ChangeDeliveryAddress(int orderId, AddressForCreationVm newDeliveryAddress)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            // null, logika
            Address newAddress = _mapper.Map<Address>(newDeliveryAddress);
            var addresdToBeRemove = order.OrderAddresses.FirstOrDefault(x => x.Address.AddressType.Name == "DeliveryAdress");
            order.OrderAddresses.Remove(order.OrderAddresses.FirstOrDefault(x => x.AddressId == addresdToBeRemove.AddressId));
            order.OrderAddresses.Add(new OrderAddress { Address = newAddress, AddressId = newAddress.Id, Order = order, OrderId = order.Id});
            _orderRepository.UpdateOrder(order);
        }

        public void ChangeLeadTime(int orderId, DateTime newLeadTimeOfOrder)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            order.LeadTime = newLeadTimeOfOrder;
            _orderRepository.UpdateOrder(order);
        }

        // to samo co wczesniej, do poprawy imho
        public ListOfOrdersVm GetOrdersToDisplay(int pageSize, int pageNo, string searchString)
        {
            List<OrderForListVm> orderForListVm = _orderRepository.GetAllOrders()
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

        // to samo co wczesniej, do poprawy imho
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

        // to samo co wczesniej, do poprawy imho
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

        // to samo co wczesniej, do poprawy imho
        public OrderForCreationVm GetOrderForCreationVmById(int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderForCreationVm orderForCreationVm = _mapper.Map<OrderForCreationVm>(order);

            return orderForCreationVm;
        }

        // to samo co wczesniej, do poprawy imho
        // entery
        public OrderForSummaryVm GetOrderSummaryVmById(int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderForSummaryVm orderForCreationVm = _mapper.Map<OrderForSummaryVm>(order);

            return orderForCreationVm;
        }

        public void RemoveProduct(int productId, int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderProduct orderProductTobeRemoved =  order.OrderProducts.FirstOrDefault(x => x.ProductId == productId);
            order.OrderProducts.Remove(orderProductTobeRemoved);
            _orderRepository.UpdateOrder(order);
        }

        // do one linera
        public void ChangeOrderStatus(int orderId, int statusId)
        {
            _orderRepository.ChangeStatusOfOrder(orderId, statusId);
        }

        // do one linera
        public OrderForViewVm GetOrderToView(int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderForViewVm orderForView = _mapper.Map<OrderForViewVm>(order);

            return orderForView;
        }
    }
}
