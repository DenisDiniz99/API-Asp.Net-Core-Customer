using Api_Customer_Business.Contracts;
using Api_Customer_Business.Notifications;
using Api_Customer_Business.Services;
using Api_Customer_Data.Contexts;
using Api_Customer_Data.Repositories;
using Api_Customer_Domain.Contracts.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api_Customer_Api.Configurations
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection AddDependecyInjection(this IServiceCollection services)
        {
            //Context: ApiContext
            services.AddScoped<ApiContext>();

            //Repositories:
            //IAddressRepository - AddressRepository
            //ICustomerRepository - CustomerRepository
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            //Services:
            //IAddressService - AddressService
            //ICustomerService - CustomerService
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICustomerService, CustomerService>();

            //Notifications:
            //INotifier, Notifier
            services.AddScoped<INotifier, Notifier>();

            //AutoMapper
            services.AddScoped<IMapper, Mapper>();

            return services;
        }
        
    }
}
