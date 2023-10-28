using Academy.Project.Domain.Abstracts;
using Academy.Project.Domain.Commands;
using Academy.Project.Domain.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Academy.Project.Restful.Restful.Commands.Customer;

public static class CreateCustomerCommandHandler
{
    [FunctionName("CreateCustomerCommandHandler")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
        CreateCustomerCommand command,
        [CosmosDB(databaseName: "Delivery", containerName: "Customer", Connection = "CosmosDBConnection", CreateIfNotExists = true, PartitionKey = "/partitionKey")]
        out dynamic entityCollector,
        [ServiceBus("customer-created", Connection = "ServiceBusConnectionString")]
        out IEvent eventCollector,
        ILogger log)
    {
        var customerEntity = CustomerEntity.CreateCustomer(command);
        
        entityCollector = customerEntity.customerEntity;
        eventCollector = customerEntity.customerCreatedEvent;
        
        return new OkObjectResult(new
        {
            customerId = customerEntity.customerEntity.Id,
            addressState = customerEntity.customerEntity.AddressStatus,
        });
    }
}