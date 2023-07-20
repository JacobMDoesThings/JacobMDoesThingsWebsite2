namespace JacobMDoesThingsWebsite2.Repo.Entities;

/// <summary>
/// PageVisitEntity. 
/// </summary>
public class PageVisitEntity : IValidatableObject
{
    private const string DocumentType = nameof(PageVisitEntity);

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("sessioninformationid")]
    public string? SessionInformationEntityId { get; set; }

    /// <summary>
    /// The URI of the endpoint visited.
    /// </summary>
    public string URI { get; set; } = string.Empty;

    /// <summary>
    /// The time in which visit started.
    /// </summary>
    public DateTimeOffset StartTime { get; set; }

    /// <summary>
    /// The time in which the visit ended.
    /// </summary>
    public DateTimeOffset EndTime { get; set; }

    ///<inheritdoc/>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(EndTime < StartTime) 
        {
            yield return new ValidationResult($"{EndTime} cannot be before {StartTime}.", new[] { nameof(StartTime), nameof(EndTime) });
        }
    }
}
