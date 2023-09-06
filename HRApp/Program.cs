using HPApp.Infrastructure;
using HRApp.Application;
using HRApp.Application.Interfaces;
using HRApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HRApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var builder = new HostBuilder()        
               
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddSingleton<Form1>();
                 services.AddSingleton<CreateEmployeeForm>();
                 services.AddSingleton<CreateNewPostForm>();
                 services.AddInfrastructure(hostContext.Configuration);
                 services.AddApplication(hostContext.Configuration);                

             });
            
            ApplicationConfiguration.Initialize();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {

                var service = serviceScope.ServiceProvider;

                try
                {
                    var form1 = service.GetRequiredService<Form1>();
                    System.Windows.Forms.Application.Run(form1);
                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!!!");
                }
            }


            //Application.Run(new Form1());
        }
    }
}