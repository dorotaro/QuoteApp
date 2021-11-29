using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Services_aka_Domain
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomainServices (this IServiceCollection services)
        {
            services.AddPersistenceServices();
            services.AddSingleton<IQuoteService, QuoteService>();
            return services;
        }
    }
}
