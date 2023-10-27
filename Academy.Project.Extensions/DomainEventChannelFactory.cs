using System.Threading.Channels;

namespace Academy.Project.Extensions
{
    public class DomainEventChannelFactory : IDomainEventChannelFactory
    {
        private readonly DomainEventChannelClient _domainEventChannelClient;

        public DomainEventChannelFactory(Channel<INotification> channel)
        {
            _domainEventChannelClient = new DomainEventChannelClient(channel);
        }
        
        public DomainEventChannelClient CreateDomainEventChannelClient()
        {
            return this._domainEventChannelClient;
        }
    }
}
