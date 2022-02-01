using CafeMVC.Domain.Interfaces;
using CafeMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CafeMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();

            return services;

        }
    }
}
