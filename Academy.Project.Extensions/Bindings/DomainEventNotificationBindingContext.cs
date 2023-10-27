namespace Academy.Project.Extensions.Bindings
{
    public class DomainEventNotificationBindingContext
    {
        public DomainEventNotificationAttribute attribute;
        public DomainEventChannelClient client;

        public DomainEventNotificationBindingContext(DomainEventNotificationAttribute attribute, DomainEventChannelClient client)
        {
            this.attribute = attribute;
            this.client = client;
        }
    }
}
