using Academy.Project.Extensions.Triggers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Academy.Project.Restful.Reactive.DomainEventHandlers.CheckFinancialStatusHandler;

public static class CheckFinancialStatusHandler
{
    [FunctionName("CheckFinancialStatusHandler")]
    public static void Run([DomainEventTrigger] string customerCreatedEvent,
        ILogger log)
    {
        log.LogTrace("CheckFinancialStatusHandler");
    }
}