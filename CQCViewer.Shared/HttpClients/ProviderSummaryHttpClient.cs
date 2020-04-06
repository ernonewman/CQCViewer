using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CQCViewer.Shared.Models;

namespace CQCViewer.Shared.HttpClients
{
    public class ProviderSummaryHttpClient
    {
        private HttpClient _client;

        public ProviderSummaryHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<ProviderSummary> GetContentFromClient()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true
                };


                var json = await _client.GetStreamAsync("https://api.cqc.org.uk/public/v1/providers").ConfigureAwait(false);

                return await JsonSerializer.DeserializeAsync<ProviderSummary>(json, options);
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
    }
}
