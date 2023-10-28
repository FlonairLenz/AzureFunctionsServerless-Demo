using Academy.Project.Domain.Customer;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Academy.Project.Restful.Reactive.DomainEventHandlers.CheckFinancialStatusHandler;

public static class CheckFinancialStatusHandler
{
    [FunctionName("CheckFinancialStatusHandler")]
    public static void Run(
        [ServiceBusTrigger("customer-created", "check-financial-status", Connection = "ServiceBusConnectionString")] CustomerCreatedEvent customerCreatedEvent,
        ILogger log)
    {
        log.LogWarning("CheckFinancialStatusHandler");
    }
}