﻿using AutoMapper;
using CafeMVC.Application.Helpers;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.Services.Helpers;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeMVC.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IAddressService _addressService;
        private readonly IContactDetailService _contactDetailService;
        private ICustomerService _customerService;
        public CartService(IMapper mapper, IProductRepository productRepository, IProductService productService, IAddressService addressService, IContactDetailService contactDetailService, ICustomerService customerService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productService = productService;
            _addressService = addressService;
            _contactDetailService = contactDetailService;
            _customerService = customerService;
        }
        private void UpdateCartDataOnView(ISession session)
        {
            UpdateProductsQuantity(session);
            UpdateCartQuote(session);
        }

        private void UpdateCartQuote(ISession session)
        {
            decimal overallOrderPrice = 0;
            if (SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart") != null)
            {
                overallOrderPrice = Helpers.Helper
                    .SumUpListOfDecimals(SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart").Select(x => x.OverallPrice).ToList());
            }

            session.SetString("total", overallOrderPrice.ToString());
        }

        private void UpdateProductsQuantity(ISession session)
        {
            int qty = 0;
            if (SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart") != null)
            {
                qty = Helpers.Helper
                    .SumUpListOfInts(SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart").Select(x => x.Quantity).ToList());

            }
            session.SetInt32("qty", qty);
        }

        private int DoesItExist(int id, ISession session)
        {
            List<ProductForOrderForCreationVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductVm.Id.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }
        private decimal GetDeliveryCharge(bool isCollection, List<AddressForCreationVm> addresses, ISession session)
        {
            if (isCollection)
            {
                return 0;
            }
            else
            {
                Helper helper = new Helper();
                string postcode = addresses.FirstOrDefault(x => x.AddressTypeId == 2).ZipCode;
                decimal deliveryCharge = helper.CountDeliveryCharge(postcode);
                UpdateTotalPriceWithDeliveryCahrge(deliveryCharge, session);

                return deliveryCharge;
            }


        }

        private void UpdateTotalPriceWithDeliveryCahrge(decimal deliveryCharge, ISession session)
        {
            string totatlString = session.GetString("total");
            decimal totalPrice = Decimal.Parse(totatlString);
            totalPrice += deliveryCharge;

            session.SetString("total", totalPrice.ToString());
        }

        private ProductForOrderForCreationVm CreateNewOrderedProduct(int productId, int quantity)
        {
            ProductForOrderForCreationVm newOrderedProduct = new()
            {
                BasePrice = _productRepository.GetProductById(productId).Price,
                Quantity = quantity,
                OverallPrice = (decimal)quantity * _productRepository.GetProductById(productId).Price,
                ProductVm = _mapper.Map<ProductForViewVm>(_productRepository.GetProductById(productId)),
                ProductId = productId

            };

            return newOrderedProduct;
        }
        private List<AddressForCreationVm> PrepareAddressesForCustomerInformation(CartInformation cartInformation)
        {
            List<AddressForCreationVm> addresses;
            addresses = new()
                {
                    new AddressForCreationVm(),
                };

            if (cartInformation.IsCollection == false)
            {
                if (cartInformation.PaymentTypeId == 1)
                {
                    if (cartInformation.Postcode != null)
                        addresses.Add(new AddressForCreationVm() { ZipCode = cartInformation.Postcode });
                    else
                    {
                        var deliveryAddress = _addressService.GetAddressToEdit(cartInformation.AddressId);
                        addresses.Add(deliveryAddress);
                    }

                }
                else
                {
                    if (cartInformation.Postcode != null)
                        addresses[0].ZipCode = cartInformation.Postcode;
                    else
                    {
                        addresses[0] = _addressService.GetAddressToEdit(cartInformation.AddressId);
                    }
                }
            }

            return addresses;
        }
        public void AddProductToCart(int quantity, int productId, ISession session)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart") == null)
            {
                List<ProductForOrderForCreationVm> cart = new()
                {
                    CreateNewOrderedProduct(productId, quantity)
                };
                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }
            else
            {
                List<ProductForOrderForCreationVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart");
                int index = DoesItExist(productId, session);
                if (index != -1)
                {
                    cart[index].Quantity += quantity;
                    cart[index].OverallPrice = cart[index].BasePrice * (decimal)cart[index].Quantity;
                }
                else
                {
                    cart.Add(CreateNewOrderedProduct(productId, quantity));
                }

                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }

            UpdateCartDataOnView(session);
        }

        public void RemoveProductFromCart(int productId, ISession session)
        {
            List<ProductForOrderForCreationVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart");
            if (cart.FirstOrDefault(x => x.ProductVm.Id == productId) != null)
            {
                cart.Remove(cart.FirstOrDefault(x => x.ProductVm.Id == productId));
                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }
            UpdateCartDataOnView(session);
        }

        public void UpdateCartProduct(int quantity, int productId, ISession session)
        {
            List<ProductForOrderForCreationVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart");
            if (cart.FirstOrDefault(x => x.ProductVm.Id == productId) != null)
            {
                int index = cart.IndexOf(cart.FirstOrDefault(x => x.ProductVm.Id == productId));
                cart[index].Quantity = quantity;
                cart[index].OverallPrice = cart[index].BasePrice * quantity;
                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }
            UpdateCartDataOnView(session);
        }

        public List<ProductForOrderForCreationVm> GetListOfCartProducts(ISession session)
        {
            List<ProductForOrderForCreationVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderForCreationVm>>(session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].ProductVm = _productService.GetProductForViewById(cart[i].ProductVm.Id);
            }

            return cart;
        }

        public decimal GetTotalPrice(ISession session)
        {
            string totalprice = session.GetString("total");
            Decimal totalDecimalPrice = Decimal.Parse(totalprice);

            return totalDecimalPrice;
        }
        public OrderForCreationVm GetOrderFromCart(CartInformation cartInformation, ISession session)
        {
            OrderForCreationVm newOrder = new()
            {
                IsCollection = cartInformation.IsCollection,
                Payment = new PaymentForCreationVm()
                {
                    PaymentTypeId = cartInformation.PaymentTypeId,
                    PaymentType = new()
                    {
                        Name = ""
                    }
                },
                TotalPrice = GetTotalPrice(session),
                Products = GetListOfCartProducts(session),


            };
            newOrder.Addresses = PrepareAddressesForCustomerInformation(cartInformation);

            if (cartInformation.CustomerId != 0)
            {
                if(_addressService.GetAllAddressesForCreationByCustomerId(cartInformation.CustomerId) != null)
                {
                newOrder.UserAddresses = _addressService.GetAllAddressesForCreationByCustomerId(cartInformation.CustomerId);

                }
                newOrder.CustomerId = cartInformation.CustomerId;
                newOrder.UserContactDetails = _contactDetailService.GetAllContactDetailsForCreation(cartInformation.CustomerId);
                newOrder.Customer = new() { FirstName = _customerService.GetCustomerFirstName(cartInformation.CustomerId), 
                    Surname = _customerService.GetCustomerSurnameName(cartInformation.CustomerId) };



            }
            SessionHelper.SetObjectAsJson(session, "order", newOrder);

            return newOrder;
        }


        public OrderForCreationVm UpdateOrderForCheckout(OrderForCreationVm newOrder, ISession session)
        {
            OrderForCreationVm order = SessionHelper.GetObjectFromJson<OrderForCreationVm>(session, "order");
            order.ContactDetails = newOrder.ContactDetails;
            order.Customer = newOrder.Customer;
            order.Addresses = newOrder.Addresses;
            order.Payment = newOrder.Payment;
            if (order.DeliveryChargeApplied == false)
            {
                order.DeliveryCharge = GetDeliveryCharge(newOrder.IsCollection, newOrder.Addresses, session);
                order.DeliveryChargeApplied = true;

            }
            if(order.CustomerId !=0)
            {
                order.CardForUserLists = _customerService.GetAllCustomersCard(order.CustomerId);
            }
            SessionHelper.SetObjectAsJson(session, "order", order);

            return order;
        }


        public CustomerForCreationVm GetCustomerInfo(ISession session)
            => SessionHelper.GetObjectFromJson<OrderForCreationVm>(session, "order").Customer;

        public List<ContactInfoForCreationVm> GetContactDetails(ISession session)
            => SessionHelper.GetObjectFromJson<OrderForCreationVm>(session, "order").ContactDetails;

        public List<AddressForCreationVm> GetAddresses(ISession session)
        => SessionHelper.GetObjectFromJson<OrderForCreationVm>(session, "order").Addresses;

        public void ClearSession(ISession session) => session.Clear();

        public decimal GetDeliveryCharge(ISession session)
            => SessionHelper.GetObjectFromJson<OrderForCreationVm>(session, "order").DeliveryCharge;


    }
}
