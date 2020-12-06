using System;
using System.Linq;
using System.Threading.Tasks;
using CQCViewer.Shared.DataContext;
using CQCViewer.Shared.HttpClients;
using CQCViewer.Shared.Interfaces.Services;
using CQCViewer.Shared.Models;
using CQCViewer.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQCViewer.UI.ConsoleApp
{
    class Program
    {
        private static object providers;

        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddHttpClient();
                    services.AddTransient<IProvidersSummaryServices, ProviderSummaryServices>();
                    services.AddTransient<IProviderDetailsServices, ProviderDetailsServices>();
                    services.AddHttpClient<ProviderSummaryHttpClient>();
                    services.AddHttpClient<ProviderDetailHttpClient>();


                }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {

                    using (var db = new SQLiteContext(@"..\CQCViewer.Shared\cqc.db"))
                    {
                        //var myService = services.GetRequiredService<IProvidersSummaryServices>();
                        var providerDetailsServices = services.GetRequiredService<IProviderDetailsServices>();

                        // var result = await providerDetailsServices.GetProviderDetails("1-1015206221");

                        // Console.WriteLine($"{result.alsoKnownAs} {result.name}");

                        // var providersSummary = await myService.GetProviderSummary(string.Empty);

                        // Console.WriteLine($"Page: {providersSummary.page}");

                        // GetDetailsAndAddToDatabase(providersSummary, db);

                        // while (providersSummary.nextPageUri != null)
                        // {
                        //     providersSummary = await myService.GetProviderSummary(providersSummary.nextPageUri);

                        //     Console.WriteLine($"Page: {providersSummary.page}");

                        //     GetDetailsAndAddToDatabase(providersSummary, db);
                        // }

                        var allDetails = db.ProviderDetails;
                        var counter = 1;

                        if (allDetails.Any())
                        {
                            foreach(var detail in allDetails)
                            {
                                try
                                {
                                    Console.WriteLine(counter);
                                    var apiDetail = await providerDetailsServices.GetProviderDetails(detail.providerId);

                                    UpdateIndividualDetails(detail, apiDetail, db);
                                }
                                catch (Exception ex)
                                {
                                }
                                counter++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return 0;
        }

        private static async void GetDetailsAndAddToDatabase(ProvidersSummary providersSummary, SQLiteContext dbContext)
        {
            foreach (var item in providersSummary.providers.ToList())
            {
                var providerDetails = dbContext.ProviderDetails.FirstOrDefault(x => x.providerId == item.providerId);

                if (providerDetails == null)
                {
                    providerDetails = new ProviderDetail
                    {
                        providerId = item.providerId,
                        name = item.providerName
                    };

                    dbContext.ProviderDetails.Add(providerDetails);
                }
            }

            dbContext.SaveChanges();
        }

        private static async void UpdateIndividualDetails(ProviderDetail detail, ProviderDetail apiDetail, SQLiteContext dbContext)
        {
            detail.locationIdsAsAString = string.Join(", ", apiDetail.locationIds);
            // detail.organisationType = apiDetail.organisationType;
            // detail.name = apiDetail.name;
            // detail.alsoKnownAs = apiDetail.alsoKnownAs;
            // detail.registrationStatus = apiDetail.registrationStatus;
            detail.registrationDate = apiDetail.registrationDate;
            // detail.website = apiDetail.website;
            // detail.postalAddressLine1 = apiDetail.postalAddressLine1;
            // detail.postalAddressLine2 = apiDetail.postalAddressLine2;
            // detail.postalAddressTownCity = apiDetail.postalAddressTownCity;
            // detail.postalAddressCounty = apiDetail.postalAddressCounty;
            // detail.region = apiDetail.region;
            // detail.postalCode = apiDetail.postalCode;
            // detail.mainPhoneNumber = apiDetail.mainPhoneNumber;

            dbContext.ProviderDetails.Update(detail);
            dbContext.SaveChanges();
        }
    }
}
