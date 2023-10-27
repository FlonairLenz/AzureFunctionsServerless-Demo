using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Academy.Project.Extensions.Bindings
{
    public class DomainEventNotificationAsyncCollector<T> : IAsyncCollector<T>
    {
        private readonly DomainEventNotificationBindingContext _context;

        public DomainEventNotificationAsyncCollector(DomainEventNotificationBindingContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(T message, CancellationToken cancellationToken = default)
        {
            await this._context.client.channel.Writer.WriteAsync(JsonConvert.SerializeObject(message), cancellationToken);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
