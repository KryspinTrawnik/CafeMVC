using AutoMapper;
using CafeMVC.Application.Helpers;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public CartService(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository, IProductService productService)
        {
            _orderRepository = orderRepository;
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
            if (SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart") != null)
            {

                overallOrderPrice = Helpers.Helper
                    .SumUpListOfDecimals(SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart").Select(x => x.OverallPrice).ToList());

            }

            session.SetString("total", overallOrderPrice.ToString());
        }

        private void UpdateProductsQuantity(ISession session)
        {
            int qty = 0;
            if (SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart") != null)
            {
                qty = Helpers.Helper
                    .SumUpListOfInts(SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart").Select(x => x.Quantity).ToList());

            }
            session.SetInt32("qty", qty);
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
                OverallPrice = (decimal)quantity * _productRepository.GetProductById(productId).Price,
                Product = _mapper.Map<ProductForViewVm>(_productRepository.GetProductById(productId))
            };

            return newOrderedProduct;
        }
        public void AddProductToCart(int quantity, int productId, ISession session)
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
                    cart[index].OverallPrice = cart[index].Price * (decimal)cart[index].Quantity;
                }
                else
                {
                    cart.Add(CreateNewOrderedProduct(productId, quantity));
                }

                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }

            UpdateCartDataOnView(session);
        }

        public OrderForCreationVm GetProductForCart(ISession session)
        {
            List<ProductForOrderVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].Product = _productService.GetProductForViewById(cart[i].Product.Id);
            }
            OrderForCreationVm orderForCart = new()
            {
                Products = cart

            };

            return orderForCart;
        }

        public void RemoveProductFromCart(int productId, ISession session)
        {
            List<ProductForOrderVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart");
            if (cart.FirstOrDefault(x => x.Product.Id == productId) != null)
            {
                cart.Remove(cart.FirstOrDefault(x => x.Product.Id == productId));
                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }
            UpdateCartDataOnView(session);
        }

        public void UpdateCartProduct(int quantity, int productId, ISession session)
        {
            List<ProductForOrderVm> cart = SessionHelper.GetObjectFromJson<List<ProductForOrderVm>>(session, "cart");
            if (cart.FirstOrDefault(x => x.Product.Id == productId) != null)
            {
                int index = cart.IndexOf(cart.FirstOrDefault(x => x.Product.Id == productId));
                cart[index].Quantity = quantity;
                cart[index].OverallPrice = cart[index].Price * quantity;
                SessionHelper.SetObjectAsJson(session, "cart", cart);
            }
            UpdateCartDataOnView(session);
        }
    }
}
