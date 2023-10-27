using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace Academy.Project.Restful.Extensions;

public static class AsyncCollectorExtension
{
    public static async Task RaiseEventAsync<T>(this IAsyncCollector<T> collector, IEnumerable<T> events, CancellationToken cancellationToken = default)
    {
        foreach (var @event in events)
        {
            await collector.AddAsync(@event, cancellationToken);
        }
    }
}