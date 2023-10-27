namespace Academy.Project.Domain.Abstracts;

public interface IAggregateRoot
{
     public IList<DomainEvent> DomainEvents { get; }
     public IList<IntegrationEvent> IntegrationEvents { get; }
}