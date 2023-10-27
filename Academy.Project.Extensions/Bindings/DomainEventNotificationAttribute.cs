using Microsoft.Azure.WebJobs.Description;

namespace Academy.Project.Extensions.Bindings
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class DomainEventNotificationAttribute: Attribute
    {
    }
}
