namespace Academy.Project.Extensions.Triggers
{
    public class DomainEventTriggerContext
    {
        public DomainEventTriggerAttribute TriggerAttribute;
        public DomainEventChannelClient Client;

        public DomainEventTriggerContext(DomainEventTriggerAttribute attribute, DomainEventChannelClient client)
        {
            this.TriggerAttribute = attribute;
            this.Client = client;
        }
    }
}
