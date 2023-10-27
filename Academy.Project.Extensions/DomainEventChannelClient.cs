using System.Threading.Channels;

namespace Academy.Project.Extensions
{
    public class DomainEventChannelClient
    {
        public readonly Channel<string> channel;

        public DomainEventChannelClient(Channel<string> channel)
        {
            this.channel = channel;
        }
    }
}
    