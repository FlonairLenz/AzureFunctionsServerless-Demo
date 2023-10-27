using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Academy.Project.Extensions.Triggers
{
    public class DomainEventTriggerBindingProvider: ITriggerBindingProvider
    {
        private DomainEventExtensionConfigProvider _provider;

        public DomainEventTriggerBindingProvider(DomainEventExtensionConfigProvider provider)
        {
            this._provider = provider;
        }

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            var parameter = context.Parameter;
            var attribute = parameter.GetCustomAttribute<DomainEventTriggerAttribute>(false);

            if (attribute == null) return Task.FromResult<ITriggerBinding>(null);
            if (parameter.ParameterType.GetInterfaces().All(i => i != typeof(INotification))) throw new InvalidOperationException("Invalid parameter type");

            var triggerBinding = new DomainEventTriggerBinding(this._provider.CreateContext(attribute));

            return Task.FromResult<ITriggerBinding>(triggerBinding);
        }
    }
}   
