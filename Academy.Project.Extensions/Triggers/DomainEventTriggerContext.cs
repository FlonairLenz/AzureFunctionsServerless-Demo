namespace Academy.Project.Extensions.Triggers
{
    public class DomainEventTriggerContext
    {
        public DomainEventTriggerAttribute TriggerAttribute;
        public Type Type;
        public DomainEventChannelClient Client;

        public DomainEventTriggerContext(DomainEventTriggerAttribute attribute, Type type, DomainEventChannelClient client)
        {
            this.TriggerAttribute = attribute;
            this.Type = type;
            this.Client = client;
        }
    }
}
