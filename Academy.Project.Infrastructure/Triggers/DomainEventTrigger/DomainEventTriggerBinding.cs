using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Academy.Project.Infrastructure.Triggers.DomainEventTrigger;

public class DomainEventTriggerBinding : ITriggerBinding
{
    private readonly DomainEventTriggerContext _context;
    
    public DomainEventTriggerBinding(DomainEventTriggerContext context)
    {
        this._context = context;
    }

    public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
    {
        var valueProvider = new DomainEventValueBinder(value);
        var bindingData = new Dictionary<string, object>();
        var triggerData = new TriggerData(valueProvider, bindingData);

        return Task.FromResult<ITriggerData>(triggerData);
    }

    public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
    {
        return Task.FromResult<IListener>(new DomainEventTriggerListener(context.Executor, this._context));
    }

    public ParameterDescriptor ToParameterDescriptor()
    {
        return new TriggerParameterDescriptor
        {
            Name = "MediatRTrigger",
            DisplayHints = new ParameterDisplayHints
            {
                Prompt = "MediatRTrigger",
                Description = "MediatR message trigger"
            }
        };
    }

    public Type TriggerValueType => typeof(string);
    public IReadOnlyDictionary<string, Type> BindingDataContract => new Dictionary<string, Type>();
}