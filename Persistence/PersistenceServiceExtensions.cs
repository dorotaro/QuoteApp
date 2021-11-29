using Microsoft.Extensions.DependencyInjection;
using Persistence.Client;
using System;
using System.Net.Http;

namespace Persistence
{
    public static class PersistenceServiceExtensions
    {
       private const string _apiKey = "37ac0ae90a5a9fb37b959ae2b235a19e";
      
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient<HttpClient>();

            var url = new Uri("https://favqs.com/api");

            services.AddHttpClient<IQuoteClient, QuoteClient>(quoteClient =>
            {
                quoteClient.BaseAddress = url;
                quoteClient.DefaultRequestHeaders.Add("Authorization", $"Token token={_apiKey}");
                
            });
                        
            return services;
        }
    }
}
