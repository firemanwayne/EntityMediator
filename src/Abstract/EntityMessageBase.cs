namespace EntityMediator.Abstract;

public abstract class EntityMessageBase
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("entityType")]
    public string? EntityType { get; set; }
}
