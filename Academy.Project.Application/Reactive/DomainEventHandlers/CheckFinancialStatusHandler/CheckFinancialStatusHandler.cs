using System.Threading.Tasks;
using Academy.Project.Domain.Abstracts;
using Academy.Project.Domain.Customer;
using Academy.Project.Domain.IntegrationEvents;
using Academy.Project.Extensions.Triggers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Academy.Project.Restful.Reactive.DomainEventHandlers.CheckFinancialStatusHandler;

public static class CheckFinancialStatusHandler
{
    [FunctionName("CheckFinancialStatusHandler")]
    public static void Run(
        [DomainEventTrigger] CustomerAddressValidated customerCreatedEvent,
        ILogger log)
    {
        log.LogWarning("CheckFinancialStatusHandler");
    }
}