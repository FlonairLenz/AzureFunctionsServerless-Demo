using System.Linq;
using System.Threading.Tasks;
using Academy.Project.Domain.Abstracts;
using Academy.Project.Domain.Commands;
using Academy.Project.Domain.Customer;
using Academy.Project.Extensions;
using Academy.Project.Extensions.Bindings;
using Academy.Project.Restful.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Academy.Project.Restful.Restful.Customer;

public static class CreateCustomerCommandHandler
{
    [FunctionName("CreateCustomerCommandHandler")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] CreateCustomerCommand command,
        [CosmosDB(databaseName: "Delivery", containerName: "Customer", Connection = "CosmosDBConnection")] IAsyncCollector<dynamic> entityCollector,
        [DomainEventNotification] IAsyncCollector<INotification> domainEventCollector,
        [ServiceBus("customer-created", Connection = "ServiceBusConnectionString")] IAsyncCollector<IntegrationEvent> integrationEventCollector,
        ILogger log)
    {
        var customerEntity = CustomerEntity.CreateCustomer(command);
        
        await entityCollector.AddAsync(customerEntity);
        await domainEventCollector.RaiseEventAsync(customerEntity.DomainEvents);
        await integrationEventCollector.RaiseEventAsync(customerEntity.IntegrationEvents);
        
        return new OkObjectResult(new
        {
            customerId = customerEntity.Id,
            addressState = customerEntity.AddressStatus,
        });
    }
}