using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.Services;
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

            return services;
        }
    }
}
