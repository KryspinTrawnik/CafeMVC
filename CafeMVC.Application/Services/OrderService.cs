using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Helpers;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly IMenuService _menuService;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, ICartService cartService, IMenuService menuService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _cartService = cartService;
            _menuService = menuService;
        }
        private bool MakePayment(PaymentForCreationVm payment)
        {
            //Left for connection with bank or paypal system
            return true;
        }
        private string GenerateOrderConfrimation(int orderId)
        {
            string todayDate = DateTime.UtcNow.ToString("MMddyy");
            string orderConfirmation = $"Order-{orderId}{todayDate}";

            return orderConfirmation;
        }

        private void AssignOrderConfirmation(Order newOrder)
        {
            string orderConfirmation = GenerateOrderConfrimation(newOrder.Id);
            newOrder.OrderConfirmation = orderConfirmation;

            _orderRepository.UpdateOrder(newOrder);
        }

        private Order PrepareOrderForSaving(OrderForCreationVm order, ISession session)
        {
            order.Customer = _cartService.GetCustomerInfo(session);

            order.ContactDetails = _cartService.GetContactDetails(session);
            order.Products = _cartService.GetListOfCartProducts(session);
            order.DateOfOrder = DateTime.Now;
            order.TotalPrice = _cartService.GetTotalPrice(session);
            order.Payment.IsCompleted = MakePayment(order.Payment);
            order.DeliveryCharge = _cartService.GetDeliveryCharge(session);
            Order orderForSaving = _mapper.Map<Order>(order);
            orderForSaving.OrderContactDetails = GetNewOrderContactDetails(order.ContactDetails);
            order.Addresses = _cartService.GetAddresses(session);
            if (order.Addresses != null)
            {
                orderForSaving.OrderAddresses = GetNewOrderAdresses(order.Addresses);

            }
            if(orderForSaving.Payment.PaymentTypeId ==1 )
            {
                orderForSaving.Customer.PaymentCards = new List<PaymentCard>
                {
                    orderForSaving.Payment.PaymentCard
                };
            }
            orderForSaving.StatusId = 1; // status open

            return orderForSaving;
        }

        private ICollection<OrderAddress> GetNewOrderAdresses(List<AddressForCreationVm> addresses)
        {
            List<OrderAddress> orderAddresses = new();
            foreach (var address in addresses)
            {
                OrderAddress orderAddress = new()
                {
                    Address = _mapper.Map<Address>(address)
                };
                orderAddresses.Add(orderAddress);
            }

            return orderAddresses;
        }

        private ICollection<OrderContactDetail> GetNewOrderContactDetails(List<ContactInfoForCreationVm> contactDetails)
        {
            List<OrderContactDetail> newOrderContactDetails = new();
            foreach (var contactInfoForCreation in contactDetails)
            {
                newOrderContactDetails.Add(new OrderContactDetail()
                {
                    ContactDetail = _mapper.Map<ContactDetail>(contactInfoForCreation)
                }
                );
            }

            return newOrderContactDetails;
        }

        private List<PaymentTypeForCreationVm> GetAllPaymentTypes()
           => _orderRepository.GetAllPaymenTypes().ProjectTo<PaymentTypeForCreationVm>(_mapper.ConfigurationProvider).ToList();

        private AddressForSummaryVm GetDeliveryAddressFromOrder(int orderId)
        {
            Address deliveryAddress = _orderRepository.GetAllAddressesFromOrder(orderId).FirstOrDefault(x => x.AddressTypeId == 2);

            return _mapper.Map<AddressForSummaryVm>(deliveryAddress);
        }
        private List<CustomerContactInfoForViewVm> GetContactDetailsFromOrder(int orderId) =>
            _orderRepository.GetAllContactDetailsFromOrder(orderId)
            .ProjectTo<CustomerContactInfoForViewVm>(_mapper.ConfigurationProvider).ToList();



        public int AddOrder(OrderForCreationVm order, ISession session)
        {
            Order newOrder = PrepareOrderForSaving(order, session);

            int orderId = _orderRepository.AddNewOrder(newOrder);

            AssignOrderConfirmation(newOrder);

            _cartService.ClearSession(session);

            return orderId;
        }
        public void ChangeLeadTime(int orderId, DateTime newLeadTimeOfOrder)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            order.LeadTime = newLeadTimeOfOrder;
            _orderRepository.UpdateOrder(order);
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

        public OrderForSummaryVm GetOrderSummaryVmById(int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderForSummaryVm orderForSummaryVm = _mapper.Map<OrderForSummaryVm>(order);
            orderForSummaryVm.Products = _mapper.Map<List<ProductForOrderSummaryVm>>(order.OrderedProductsDetails);
            orderForSummaryVm.ContactDetails = GetContactDetailsFromOrder(orderId);

            if (order.IsCollection == false)
            {
                orderForSummaryVm.DeliveryAddress = GetDeliveryAddressFromOrder(orderId);
            }

            return orderForSummaryVm;
        }

        public void RemoveProduct(int productId, int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderedProductDetails orderProductTobeRemoved = order.OrderedProductsDetails.FirstOrDefault(x => x.ProductId == productId);
            order.OrderedProductsDetails.Remove(orderProductTobeRemoved);
            _orderRepository.UpdateOrder(order);
        }

        public void ChangeOrderStatus(int orderId, int statusId) => _orderRepository.ChangeStatusOfOrder(orderId, statusId);

        public OrderForViewVm GetOrderToView(int orderId)
        {
            Order order = _orderRepository.GetOrderById(orderId);
            OrderForViewVm  orderForViewVm = _mapper.Map < OrderForViewVm >(order);
            orderForViewVm.AllStatuses = _orderRepository.GetAllStatuses().ProjectTo<StatusForCreationVm>(_mapper.ConfigurationProvider).ToList();
            orderForViewVm.ContactDetails = GetContactDetailsFromOrder(orderId);
            orderForViewVm.Products = _mapper.Map<List<ProductForOrderViewVm>>(order.OrderedProductsDetails);
            if (order.IsCollection == false)
            {
                orderForViewVm.DeliveryAddress = GetDeliveryAddressFromOrder(orderId);
            }

            return orderForViewVm;
        }

        public OrderForCreationVm GetOrderForCart(ISession session)
        {
            OrderForCreationVm newOrder = new()
            {
                Payment = new()
                {
                    AllPaymentTypes = GetAllPaymentTypes()
                },
            };
            if (SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart") != null)
            {
                newOrder.Products = _cartService.GetListOfCartProducts(session);
            };

            return newOrder;
        }

        public OrderForCreationVm AssignAddressesTypes(OrderForCreationVm newOrder)
        {
            bool condition = newOrder.Payment.PaymentType.Name != "Card";
            newOrder.Addresses[0].AddressTypeId = condition ? 2 : 1;

            if (condition == false)
            {
                newOrder.Addresses[1].AddressTypeId = 2;
            }

            return newOrder;
        }

        public ListsOfOrdersForIndexVm GetOrdersForIndex()
        {
            ListsOfOrdersForIndexVm listsOfOrdersForIndexVm = new ListsOfOrdersForIndexVm();
            List<Order> openOrdersForList = _orderRepository.GetOpenOrders().ToList();
            List<Order> closedOrdersForList = _orderRepository.GetClosedOrders().ToList();
            if (openOrdersForList != null)
            {
                List<OrderForListVm> openOrdersForListVm = _mapper.Map<List<OrderForListVm>>(openOrdersForList);
                listsOfOrdersForIndexVm.ListOfOpenOrders = openOrdersForListVm;
            }
            if (closedOrdersForList != null)
            {
                List<OrderForListVm> closedOrdersForListVm = _mapper.Map<List<OrderForListVm>>(closedOrdersForList);
                listsOfOrdersForIndexVm.ListOfClosedOrders = closedOrdersForListVm;
            }

            return listsOfOrdersForIndexVm;
        }

        public AdminDashboardVm GetDashboardVm()
        {
            List<Order> openOrdersForList = _orderRepository.GetOpenOrders().ToList();
            AdminDashboardVm adminDashboard = new();
            if (openOrdersForList != null)
            {
                List<OrderForListVm> openOrdersForListVm = _mapper.Map<List<OrderForListVm>>(openOrdersForList);
                adminDashboard.ListOfOpenOrders = openOrdersForListVm;
            }
            adminDashboard.ListOfOpenMenus = _menuService.GetPublicMenus();

            return adminDashboard;

        }
    }

}
