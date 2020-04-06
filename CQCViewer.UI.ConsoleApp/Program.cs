using System;
using System.Linq;
using System.Threading.Tasks;
using CQCViewer.Shared.HttpClients;
using CQCViewer.Shared.Interfaces.Services;
using CQCViewer.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQCViewer.UI.ConsoleApp
{
    class Program
    {
        private static object providers;

        //static void Main(string[] args)
        //{
        //    //setup our DI
        //    var serviceProvider = new ServiceCollection()
        //        .AddLogging()
        //        .AddSingleton<IProvidersSummaryServices, ProviderSummaryServices>()
        //        .AddHttpClient<ProviderSummaryHttpClient>()
        //        .BuildServiceProvider();

        //    //do the actual work here
        //    //var bar = serviceProvider.GetService<IBarService>();
        //    //bar.DoSomeRealWork();
        //}

        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient();
                    services.AddSingleton<IProvidersSummaryServices, ProviderSummaryServices>();
                    services.AddSingleton<IProviderDetailsServices, ProviderDetailsServices>();
                    services.AddHttpClient<ProviderSummaryHttpClient>();
                    services.AddHttpClient<ProviderDetailHttpClient>();


                }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myService = services.GetRequiredService<IProvidersSummaryServices>();
                    var providerDetailsServices = services.GetRequiredService<IProviderDetailsServices>();

                    var providersSummary = await myService.GetProviderSummary(string.Empty);

                    foreach (var item in providersSummary.providers.ToList().Take(10))
                    {
                        var providerDetails = await providerDetailsServices.GetProviderDetails(item.providerId);

                        Console.WriteLine($"Name: {providerDetails.name} Phone Number: {providerDetails.mainPhoneNumber}");
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return 0;
        }
    }
}
