using System.Threading.Channels;
using Academy.Project.Domain.Abstracts;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Academy.Project.Infrastructure.Triggers.DomainEventTrigger;

public class DomainEventExtensionConfigProvider : IExtensionConfigProvider
{
    private readonly Channel<DomainEvent> _channel;
    
    public DomainEventExtensionConfigProvider(Channel<DomainEvent> channel)
    {
        this._channel = channel;
    }
    
    public void Initialize(ExtensionConfigContext context)
    {
        context.AddBindingRule<DomainEventTriggerAttribute>().BindToTrigger(new DomainEventTriggerBindingProvider(this));
    }
    
    public DomainEventTriggerContext CreateContext(DomainEventTriggerAttribute attribute)
    {
        return new DomainEventTriggerContext(attribute, this._channel);
    }
}