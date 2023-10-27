using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Academy.Project.Infrastructure.Triggers.DomainEventTrigger;

public class DomainEventTriggerBindingProvider : ITriggerBindingProvider
{
    private readonly DomainEventExtensionConfigProvider _provider;
    
    public DomainEventTriggerBindingProvider(DomainEventExtensionConfigProvider provider)
    {
        this._provider = provider;
    }
    
    public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
    {
        var parameter = context.Parameter;
        var attribute = parameter.GetCustomAttribute<DomainEventTriggerAttribute>(false);

        var triggerBinding = new DomainEventTriggerBinding(this._provider.CreateContext(attribute));

        return Task.FromResult<ITriggerBinding>(triggerBinding);
    }
}