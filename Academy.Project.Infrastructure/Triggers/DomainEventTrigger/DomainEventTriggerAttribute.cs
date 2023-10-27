using Microsoft.Azure.WebJobs.Description;

namespace Academy.Project.Infrastructure.Triggers.DomainEventTrigger
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class DomainEventTriggerAttribute: Attribute
    {
        public DomainEventTriggerAttribute()
        {
        }
    }
}