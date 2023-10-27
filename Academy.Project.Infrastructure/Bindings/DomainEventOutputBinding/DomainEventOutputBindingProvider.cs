using System.Threading.Channels;
using Academy.Project.Domain.Abstracts;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Academy.Project.Infrastructure.Bindings.DomainEventOutputBinding;

[Extension("DomainEventOutputBinding")]
public class DomainEventOutputBindingProvider : IExtensionConfigProvider
{
    private readonly Channel<DomainEvent> _channel;
    
    public DomainEventOutputBindingProvider(Channel<DomainEvent> channel)
    {
        this._channel = channel;
    }
    
    public void Initialize(ExtensionConfigContext context)
    {
        context.AddBindingRule<DomainEventNotificationAttribute>().BindToCollector(attribute => new DomainEventOutputCollector(this._channel, attribute));
    }
}