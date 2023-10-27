using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Academy.Project.Extensions.Bindings
{
    public class DomainEventNotificationAsyncCollector : IAsyncCollector<INotification>
    {
        private readonly DomainEventNotificationBindingContext _context;

        public DomainEventNotificationAsyncCollector(DomainEventNotificationBindingContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(INotification message, CancellationToken cancellationToken = default)
        {
            await this._context.client.channel.Writer.WriteAsync(message, cancellationToken);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
