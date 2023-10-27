using System.Threading.Channels;
using Academy.Project.Domain.Abstracts;

namespace Academy.Project.Infrastructure.Triggers.DomainEventTrigger;

public class DomainEventTriggerContext
{
    public DomainEventTriggerAttribute TriggerAttribute { get; }
    public ChannelReader<DomainEvent> ChannelReader { get; }

    public DomainEventTriggerContext(DomainEventTriggerAttribute attribute, ChannelReader<DomainEvent> channelReader)
    {
        this.TriggerAttribute = attribute;
        this.ChannelReader = channelReader;
    }
}