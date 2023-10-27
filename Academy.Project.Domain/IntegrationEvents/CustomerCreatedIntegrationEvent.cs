using Academy.Project.Domain.Abstracts;

namespace Academy.Project.Domain.IntegrationEvents;

public sealed record CustomerCreatedIntegrationEvent : IntegrationEvent
{
    public CustomerCreatedIntegrationEvent() : base("20017")
    {
    }
}