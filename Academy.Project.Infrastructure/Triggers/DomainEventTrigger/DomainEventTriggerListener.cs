using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Newtonsoft.Json;

namespace Academy.Project.Infrastructure.Triggers.DomainEventTrigger;

public class DomainEventTriggerListener : IListener
{
    private readonly ITriggeredFunctionExecutor _executor;
    private readonly DomainEventTriggerContext _context;
    
    public DomainEventTriggerListener(ITriggeredFunctionExecutor executor, DomainEventTriggerContext context)
    {
        this._executor = executor;
        this._context = context;
    }
    
    public void Dispose()
    {
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            while (!this._context.ChannelReader.Completion.IsCompleted)
            {
                await this._context.ChannelReader.WaitToReadAsync(cancellationToken);
                var domainEvent = await this._context.ChannelReader.ReadAsync(cancellationToken);
                var json = JsonConvert.SerializeObject(domainEvent);
                var triggeredData = new TriggeredFunctionData
                {
                    TriggerValue = json,
                };
                await this._executor.TryExecuteAsync(triggeredData, cancellationToken);
            }
        }, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void Cancel()
    {
    }
}