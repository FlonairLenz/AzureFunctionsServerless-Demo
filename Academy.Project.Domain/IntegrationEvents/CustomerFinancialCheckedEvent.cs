using Academy.Project.Domain.Abstracts;

namespace Academy.Project.Domain.IntegrationEvents;

public record CustomerFinancialCheckedEvent(string CustomerId) : IntegrationEvent("20800");