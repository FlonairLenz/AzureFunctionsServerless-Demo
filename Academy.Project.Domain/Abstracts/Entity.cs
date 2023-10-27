using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Academy.Project.Domain.Abstracts;

public abstract record Entity : IAggregateRoot
{
    protected Entity()
    {
        this.Id = Guid.NewGuid().ToString();
        this.PartitionKey = this.Id;
    }
    
    [JsonIgnore]
    public IList<DomainEvent> DomainEvents { get; } = new List<DomainEvent>();

    [JsonIgnore]
    public IList<IntegrationEvent> IntegrationEvents { get; } = new List<IntegrationEvent>();
    
    [JsonProperty(PropertyName = "partitionKey")]
    public string PartitionKey { get; init; }
    
    [JsonProperty(PropertyName = "id")]
    public string Id { get; init; }
}