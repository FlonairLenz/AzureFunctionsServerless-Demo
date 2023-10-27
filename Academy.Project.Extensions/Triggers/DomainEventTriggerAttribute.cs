using Microsoft.Azure.WebJobs.Description;

namespace Academy.Project.Extensions.Triggers
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class DomainEventTriggerAttribute: Attribute
    {
    }
}
