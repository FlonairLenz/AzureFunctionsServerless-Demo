using System.Threading.Tasks;
using Academy.Project.Domain.Customer;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Academy.Project.Restful.Reactive.DomainEventHandlers.CheckCustomerAddressHandler;

public static class CheckCustomerAddressHandler
{
    [FunctionName("CheckCustomerAddressHandler")]
    public static async Task Run(
        [ServiceBusTrigger("customer-created", "check-customer-address", Connection = "ServiceBusConnectionString")] CustomerCreatedEvent customerCreatedEvent,
        ILogger log)
    {
    }
}