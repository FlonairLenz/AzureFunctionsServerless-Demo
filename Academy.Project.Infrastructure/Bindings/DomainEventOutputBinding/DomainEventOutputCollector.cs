using System.Threading.Channels;
using Academy.Project.Domain.Abstracts;
using MediatR;
using Microsoft.Azure.WebJobs;

namespace Academy.Project.Infrastructure.Bindings.DomainEventOutputBinding;

public class DomainEventOutputCollector : IAsyncCollector<DomainEvent>
{
    private readonly Channel<DomainEvent> _channel;
    
    public DomainEventOutputCollector(Channel<DomainEvent> channel, DomainEventNotificationAttribute attr)
    {
        this._channel = channel;
    }

    public async Task AddAsync(DomainEvent item, CancellationToken cancellationToken = default)
    {
        await this._channel.Writer.WriteAsync(item, cancellationToken);
    }

    public Task FlushAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}