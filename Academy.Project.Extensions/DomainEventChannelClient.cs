using System.Threading.Channels;

namespace Academy.Project.Extensions
{
    public class DomainEventChannelClient
    {
        public readonly Channel<INotification> channel;

        public DomainEventChannelClient(Channel<INotification> channel)
        {
            this.channel = channel;
        }
    }
}
    