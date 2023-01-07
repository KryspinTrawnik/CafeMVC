using AutoMapper;
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

        public CartService(IMapper mapper, IProductRepository productRepository, IProductService productService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productService = productService;
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
            if(isCollection)
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
            if (cartInformation.IsCollection == false)
            {
                newOrder.Addresses =  new()
                {
                    new AddressForCreationVm(),
                    new AddressForCreationVm()
                    {
                        ZipCode = cartInformation.Postcode
                    }
                };
            }
                SessionHelper.SetObjectAsJson(session, "order", newOrder);

            return newOrder;
        }

        public OrderForCreationVm UpdateOrderForCheckout(OrderForCreationVm newOrder, ISession session)
        {
            OrderForCreationVm order = SessionHelper.GetObjectFromJson<OrderForCreationVm>(session, "order");
            order.DeliveryCharge = GetDeliveryCharge(newOrder.IsCollection, newOrder.Addresses, session);
            order.ContactDetails = newOrder.ContactDetails;
            order.Customer = newOrder.Customer;
            order.Addresses = newOrder.Addresses;
            order.Payment = newOrder.Payment;
            newOrder.DeliveryCharge = GetDeliveryCharge(newOrder.IsCollection, newOrder.Addresses, session);
            SessionHelper.SetObjectAsJson(session, "order", newOrder);

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
