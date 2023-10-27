using System.Threading.Tasks;
using Academy.Project.Domain.Abstracts;
using Academy.Project.Domain.Customer;
using Academy.Project.Domain.IntegrationEvents;
using Academy.Project.Extensions.Triggers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Academy.Project.Restful.Reactive.DomainEventHandlers.ValidateCustomerAddress;

public static class ValidateCustomerAddressHandler
{
    [FunctionName("ValidateCustomerAddressHandler")]
    public static async Task Run([DomainEventTrigger] CustomerCreatedEvent customerCreatedEvent,
        [ServiceBus("customer-financial-checked", Connection = "ServiceBusConnectionString")] IAsyncCollector<IntegrationEvent> integrationEventCollector,
        ILogger log)
    {
        await Task.Delay(7000); // hard work to do
        // TODO flz : Sometime here it got an problem
        await integrationEventCollector.AddAsync(new CustomerFinancialCheckedEvent(customerCreatedEvent.CustomerId));
    }
}