using Academy.Project.Domain.Abstracts;
using Academy.Project.Domain.ValueObjects;

namespace Academy.Project.Domain.Customer;

public record CustomerCreatedEvent : DomainEvent
{
    public string CustomerId { get; init; }
    public Address Address { get; init; }
}