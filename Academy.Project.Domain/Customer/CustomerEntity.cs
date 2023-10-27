using Academy.Project.Domain.Abstracts;
using Academy.Project.Domain.Commands;
using Academy.Project.Domain.Enums;
using Academy.Project.Domain.IntegrationEvents;
using Academy.Project.Domain.ValueObjects;

namespace Academy.Project.Domain.Customer;

public record CustomerEntity : Entity
{
    private CustomerEntity(string name)
    {
        this.Name = name;
        this.Address = new Address("Teststr. 1", "Teststadt", "12345", "Testland", "Testlandkreis");
    }
    
    public string Name { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public Address Address { get; init; }
    public AddressStatus AddressStatus { get; set; }

    public static CustomerEntity CreateCustomer(CreateCustomerCommand command)
    {
        var customer = new CustomerEntity(command.Name)
        {
            AddressStatus = AddressStatus.Unknown
        };
        customer.DomainEvents.Add(new CustomerCreatedEvent(customer.Id, customer.Address));
        customer.IntegrationEvents.Add(new CustomerCreatedIntegrationEvent());
        return customer;
    }
}