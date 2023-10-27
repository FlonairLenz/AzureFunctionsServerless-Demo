using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Newtonsoft.Json;

namespace Academy.Project.Extensions.Triggers
{
    public class DomainEventListener: IListener
    {
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly DomainEventTriggerContext _context;

        public DomainEventListener(ITriggeredFunctionExecutor executor, DomainEventTriggerContext context)
        {
            this._executor = executor;
            this._context = context;
        }

        public void Cancel()
        {
        }

        public void Dispose()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                while (!this._context.Client.channel.Reader.Completion.IsCompleted)
                {
                    await this._context.Client.channel.Reader.WaitToReadAsync(cancellationToken).ConfigureAwait(false);
                    var domainEvent = await this._context.Client.channel.Reader.ReadAsync(cancellationToken)
                        .ConfigureAwait(false);
                    var triggeredData = new TriggeredFunctionData
                    {
                        TriggerValue = domainEvent,
                    };
                    var execution = this._executor.TryExecuteAsync(triggeredData, cancellationToken);
                    // await execution.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
