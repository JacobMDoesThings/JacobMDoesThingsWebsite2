namespace JacobMDoesThingsWebsite2.Repo.Entities;

/// <summary>
/// Reprents base meta data for Cosmos Entity.
/// </summary>
public abstract class BaseEntity
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    public abstract string? PartitionKey { get; set; }

    public abstract string Type { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DataType(DataType.DateTime)]
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DataType(DataType.DateTime)]
    public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.UtcNow;

    public string? Etag { get; set; }
}
