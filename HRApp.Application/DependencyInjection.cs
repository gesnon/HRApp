using HRApp.Application.Interfaces;
using HRApp.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDataService, DataService>();

            return services;
        }
    }
}
