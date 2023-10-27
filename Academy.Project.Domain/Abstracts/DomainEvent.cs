using Academy.Project.Extensions;

namespace Academy.Project.Domain.Abstracts;

public abstract record DomainEvent() : INotification;