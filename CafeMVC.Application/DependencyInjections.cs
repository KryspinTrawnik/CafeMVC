using CafeMVC.Application.Interfaces;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
// CTRL + K + E w visual studio 2019 ;)

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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ShortAddressResolver>();

            return services; // Enter przed 'return' zwieksza czytelnosc o miliard procent.
        }
    }
}
