using Academy.Project.Extensions.Bindings;
using Academy.Project.Extensions.Triggers;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Academy.Project.Extensions
{
    /// <summary>
    /// Extension Config Provider class
    /// </summary>
    public class DomainEventExtensionConfigProvider : IExtensionConfigProvider
    {
        public IDomainEventChannelFactory channelFactory;

        public DomainEventExtensionConfigProvider(IDomainEventChannelFactory channelFactory)
        {
            this.channelFactory = channelFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            var triggerRule = context.AddBindingRule<DomainEventTriggerAttribute>();
            triggerRule.BindToTrigger(new DomainEventTriggerBindingProvider(this));

            var bindingRule = context.AddBindingRule<DomainEventNotificationAttribute>();
            bindingRule.BindToCollector<INotification>(typeof(DomainEventNotificationBindingConverter), this);
        }

        public DomainEventTriggerContext CreateContext(DomainEventTriggerAttribute attribute)
        {
            return new DomainEventTriggerContext(attribute, this.channelFactory.CreateDomainEventChannelClient());
        }

        public DomainEventNotificationBindingContext CreateContext(DomainEventNotificationAttribute attribute)
        {
            return new DomainEventNotificationBindingContext(attribute, this.channelFactory.CreateDomainEventChannelClient());
        }
    }
}
