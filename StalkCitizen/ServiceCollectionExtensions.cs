using Kmd.Logic.Audit.Client;
using Kmd.Logic.Audit.Client.SerilogAzureEventHubs;
using Microsoft.Extensions.DependencyInjection;
using StalkCitizen.Services;

namespace StalkCitizen
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAudit(this IServiceCollection services, StalkCitizenConfiguration configuration)
        {
            services.AddSingleton<IAudit>(new SerilogAzureEventHubsAuditClient(
                new SerilogAzureEventHubsAuditClientConfiguration
                {
                    ConnectionString = configuration.SerilogAzureEventHubConnectionString,
                    EventSource = configuration.SerilogAzureEventHubEventSource,
                    EnrichFromLogContext = true,
                }));
            return services;
        }
        
        public static IServiceCollection AddCitizenService(this IServiceCollection services, StalkCitizenConfiguration configuration)
        {
            services.AddScoped<ICitizenService, MockCitizenService>();
            return services;
        }
        
        public static IServiceCollection AddSmsService(this IServiceCollection services, StalkCitizenConfiguration configuration)
        {
            services.AddSingleton<SmsOptions>(configuration.Sms);
            services.AddScoped<ISmsService, MockSmsService>();
            return services;
        }
        
        public static IServiceCollection AddCitizenNotifier(this IServiceCollection services, StalkCitizenConfiguration configuration)
        {
            services.AddScoped<ICitizenNotifier, MockCitizenNotifier>();
            return services;
        }
    }
}