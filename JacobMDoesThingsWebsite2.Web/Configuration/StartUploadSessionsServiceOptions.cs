namespace JacobMDoesThingsWebsite2.Web.Configuration;

/// <summary>
/// The StartUploadSessionServiceOptions provided.
/// Required for configuration.
/// </summary>
public class StartUploadSessionsServiceOptions
{
    /// <summary>
    /// The time span before service starts.
    /// </summary>
    public int DueTime { get; set; }

    /// <summary>
    /// The frequency of service.
    /// </summary>
    public int IntervalTime { get; set; } 
}
