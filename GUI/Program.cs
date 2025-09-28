using GUI.APIClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //added for DI and to use appsettings.json

            var host = Host.CreateDefaultBuilder()
           .ConfigureAppConfiguration(config =>
           {
               config.SetBasePath(AppContext.BaseDirectory);
               config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
           })
           .ConfigureServices((context, services) =>
           {
               var baseUrl = context.Configuration["ApiSettings:BaseUrl"];

               services.AddHttpClient<ApiClient>(client =>
               {
                   client.BaseAddress = new Uri(baseUrl);
               });
               services.AddTransient<AddProductForm>();
               services.AddTransient<Form1>();
           })
           .Build();

            var mainForm = host.Services.GetRequiredService<Form1>();

            Application.Run(mainForm);
        }
    }
}