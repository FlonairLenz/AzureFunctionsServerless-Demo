using Academy.Project.Domain.Customer;
using Academy.Project.Extensions.Triggers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Academy.Project.Restful.Reactive.DomainEventHandlers.ValidateCustomerAddress;

public static class ValidateCustomerAddressHandler
{
    [FunctionName("ValidateCustomerAddressHandler")]
    public static void Run([DomainEventTrigger] CustomerCreatedEvent customerCreatedEvent,
        ILogger log)
    {
        log.LogTrace("ValidateCustomerAddressHandler");
    }
}