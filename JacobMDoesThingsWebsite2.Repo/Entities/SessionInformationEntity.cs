namespace JacobMDoesThingsWebsite2.Repo.Entities;

/// <summary>
/// SessionInformationEntity.
/// </summary>
public class SessionInformationEntity : BaseEntity
{
    private const string DocumentType = nameof(SessionInformationEntity);

    /// <summary>
    /// Gets the PartitionKey for SessionInformationEntity by Id.
    /// </summary>
    public override string? PartitionKey
    {
        get => GetPartitionKey(Id!);
        set { }
    }

    /// <summary>
    /// Gets the DocumentType.
    /// </summary>
    public override string Type
    {
        get => DocumentType;
        set { }
    }

    /// <summary>
    /// The UserAgent for the session.
    /// </summary>
    public string UserAgent { get; set; } = string.Empty;

    /// <summary>
    /// The collection of all PageVisitEntities associated with a session.
    /// </summary>
    public ICollection<PageVisitEntity> PageVisitEntities { get; }

    /// <summary>
    /// The TrackingId for managing collection of visits.
    /// </summary>
    public string TrackingId { get; set; } = string.Empty;

    /// <summary>
    /// Private constructor required for ef core.
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private SessionInformationEntity()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    /// <summary>
    /// Initializes SessionInformationEntity.
    /// </summary>
    /// <param name="pageVisits">An <see cref="ICollection{T}"/> of <seealso cref="PageVisitEntities"/>.</param>
    public SessionInformationEntity(ICollection<PageVisitEntity> pageVisits)
    {
        PageVisitEntities = pageVisits;
    }

    /// <summary>
    /// Gets the PartitionKey, the Id of the Class.
    /// </summary>
    /// <param name="Id">The name of the Class.</param>
    /// <returns></returns>
    internal static string GetPartitionKey(string TrackingId) => $"{TrackingId}";
}
