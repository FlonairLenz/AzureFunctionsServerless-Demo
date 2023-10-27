using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Academy.Project.Extensions.Triggers
{
    public class DomainEventTriggerBinding: ITriggerBinding
    {
        private readonly DomainEventTriggerContext _context;

        public DomainEventTriggerBinding(DomainEventTriggerContext context)
        {
            this._context = context;
        }

        public Type TriggerValueType => typeof(string);
        public IReadOnlyDictionary<string, Type> BindingDataContract => new Dictionary<string, Type>();

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            var valueProvider = new DomainEventValueBinder(value);
            var bindingData = new Dictionary<string, object>();
            var triggerData = new TriggerData(valueProvider, bindingData);

            return Task.FromResult<ITriggerData>(triggerData);
        }

        /// <summary>
        /// Create listener class
        /// </summary>
        /// <param name="context">Listener factory context</param>
        /// <returns>A Task that contains the listenr instance</returns>
        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            var executor = context.Executor;
            var listener = new DomainEventListener(executor, this._context);

            return Task.FromResult<IListener>(listener);
        }

        /// <summary>
        /// Get binding description
        /// </summary>
        /// <returns>Retruns a string that describes the binding</returns>
        public ParameterDescriptor ToParameterDescriptor()
        {
            return new TriggerParameterDescriptor
            {
                Name = "DomainEvent",
                DisplayHints = new ParameterDisplayHints
                {
                    Prompt = "DomainEvent",
                    Description = "DomainEvent message trigger"
                }
            };
        }
    }
}
