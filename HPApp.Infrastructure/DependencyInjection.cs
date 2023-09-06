using HPApp.Infrastructure.Persistence;
using HRApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRAppContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HRAppDB;Trusted_Connection=true"));           
            services.AddScoped<IHRAppContext>(provider => provider.GetRequiredService<HRAppContext>());            
            services.AddScoped<DbInitializer>();


            return services;
        }
    }
}
