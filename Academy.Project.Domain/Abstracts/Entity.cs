using Newtonsoft.Json;

namespace Academy.Project.Domain.Abstracts;

public abstract record Entity : IAggregateRoot
{
    protected Entity()
    {
        this.Id = Guid.NewGuid().ToString();
        this.PartitionKey = this.Id;
    }
    
    [JsonProperty(PropertyName = "partitionKey")]
    public string PartitionKey { get; init; }
    
    [JsonProperty(PropertyName = "id")]
    public string Id { get; init; }
}