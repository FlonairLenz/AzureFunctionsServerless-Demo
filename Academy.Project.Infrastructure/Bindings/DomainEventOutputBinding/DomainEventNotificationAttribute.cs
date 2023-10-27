using Microsoft.Azure.WebJobs.Description;

namespace Academy.Project.Infrastructure.Bindings.DomainEventOutputBinding;

[Binding]
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
public class DomainEventNotificationAttribute : Attribute
{
}