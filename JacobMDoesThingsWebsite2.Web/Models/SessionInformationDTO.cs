namespace JacobMDoesThingsWebsite2.Web.Models;

public class SessionInformationDTO : BaseDTO
{
    /// <summary>
    /// The collection of all PageVisits associated with a session.
    /// </summary>
    public List<PageVisitDTO> PageVisits { get; set; } = new();

    /// <summary>
    /// The TrackingId for managing collection of visits.
    /// </summary>
    public string? TrackingId { get; set; } = string.Empty;

    /// <summary>
    /// The UserAgent for the session.
    /// </summary>
    public string? UserAgent { get; set; } = string.Empty;

}
