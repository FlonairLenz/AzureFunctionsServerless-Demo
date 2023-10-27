using Academy.Project.Domain.Abstracts;
using Academy.Project.Domain.ValueObjects;

namespace Academy.Project.Domain.Customer;

public record CustomerCreatedEvent(string CustomerId, Address Address) : DomainEvent
{
}