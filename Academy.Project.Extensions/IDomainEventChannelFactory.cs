namespace Academy.Project.Extensions
{
    public interface IDomainEventChannelFactory
    {
        public DomainEventChannelClient CreateDomainEventChannelClient();
    }
}
