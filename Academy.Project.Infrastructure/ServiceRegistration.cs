using System.Threading.Channels;
using Academy.Project.Domain.Abstracts;
using Academy.Project.Infrastructure.Bindings.DomainEventOutputBinding;
using Academy.Project.Infrastructure.Triggers.DomainEventTrigger;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Project.Infrastructure;

public static class ServiceRegistration
{
    public static IWebJobsBuilder ConfigureInfrastructure(this IWebJobsBuilder builder)
    {
        builder.AddExtension<DomainEventExtensionConfigProvider>();
        builder.AddExtension<DomainEventOutputBindingProvider>();
        builder.Services.AddSingleton(Channel.CreateUnbounded<DomainEvent>());
        return builder;
    }
}