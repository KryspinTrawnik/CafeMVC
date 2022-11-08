using System.Reflection;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.Services;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CafeMVC.Application
{
    public static class DependencyInjections
    {
        
       public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IContactDetailService, ContactDetailService>();
            services.AddTransient<IAllergenService, AllergenService>();
            services.AddTransient<ICartService, CartService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ShortAddressResolver>();
            
            return services;
        }


        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AddressForCreationVm>, AddressForCreationValidator>();
            services.AddTransient<IValidator<OrderForCreationVm>, OrderForCreationValidator>();

            return services;
        }   
    }
}
