using Api_Customer_Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api_Customer_Api.Configurations
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApiContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
