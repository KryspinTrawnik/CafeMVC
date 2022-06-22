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

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
    
        public void AddOrChangeNote(int orderId, string note) => _orderRepository.AddOrChangeNote(orderId, note);

        public string AddOrder(OrderForCreationVm order)
        {
            Order newOrder = _mapper.Map<Order>(order);
            int orderId = _orderRepository.AddNewOrder(newOrder);
            string orderConfirmation = GenerateOrderConfrimation(orderId);
            newOrder.OrderConfirmation = orderConfirmation;

            return orderConfirmation;
        }
        private void UpdateCartDataOnView(ISession session)
        {
            UpdateProductsQuantity(session);
            UpdateCartQuote(session);
        }

        private void UpdateCartQuote(ISession session)
        {
            double overallOrderPrice = 0;
            if (SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart") != null)
            {

                overallOrderPrice = Helpers.Helper
                    .SumUpListOfDoubles(SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart").Select(x => x.OverallPrice).ToList());

            }

            session.SetString("total", overallOrderPrice.ToString());
        }

        private void UpdateProductsQuantity( ISession session)
        {
            int qty = 0;
            if(SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart") != null)
            {
                qty = Helpers.Helper
                    .SumUpListOfInts(SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart").Select(x => x.Quantity).ToList());
                
            }
            session.SetInt32("qty", qty);
        }

        public void AddProductToOrder(int quantity, int productId, ISession session)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart") == null)
            {
                List<ProductForOrderVm> cart = new()
                {
                    CreateNewOrderedProduct(productId, quantity)
                };
                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }
            else
            {
                List<ProductForOrderVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart");
                int index = DoesItExist(productId, session);
                if (index != -1)
                {
                    cart[index].Quantity += quantity;
                    cart[index].OverallPrice = cart[index].Price * (double)quantity;
                }
                else
                {
                    cart.Add(CreateNewOrderedProduct(productId, quantity));
                }
               
                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }

                UpdateCartDataOnView(session);
        }
        private int DoesItExist(int id, ISession session)
        {
            List<ProductForOrderVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }


        private ProductForOrderVm CreateNewOrderedProduct(int productId, int quantity)
        {
            ProductForOrderVm newOrderedProduct = new()
            {
                Price = _productRepository.GetProductById(productId).Price,
                Quantity = quantity,
                OverallPrice = (double)quantity * _productRepository.GetProductById(productId).Price,
                Product = _mapper.Map<ProductForListVm>(_productRepository.GetProductById(productId))
            };

            return newOrderedProduct;
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

        private string GenerateOrderConfrimation(int orderId)
        {
            string todayDate = DateTime.UtcNow.ToString("MMddyy");
            string orderConfirmation = $"Order-{orderId}{todayDate}";

            return orderConfirmation;
        }
    }

}
