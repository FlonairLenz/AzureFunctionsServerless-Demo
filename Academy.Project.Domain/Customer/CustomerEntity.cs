using Academy.Project.Domain.Abstracts;
using Academy.Project.Domain.Commands;
using Academy.Project.Domain.Enums;
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

    public static (CustomerEntity customerEntity, CustomerCreatedEvent customerCreatedEvent) CreateCustomer(CreateCustomerCommand command)
    {
        var customer = new CustomerEntity(command.Name)
        {
            AddressStatus = AddressStatus.Unknown
        };
        
        return (customer, new CustomerCreatedEvent(customer.Id, customer.Address));
    }
}