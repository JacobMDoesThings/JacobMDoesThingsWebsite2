namespace JacobMDoesThingsWebsite2.Web.Configuration;

/// <summary>
/// The SessionFunctionsCallerOptions.
/// Required for configuration.
/// </summary>
public class OdataServiceCallerOptions
{
    /// <summary>
    /// The BaseURI of the odata service.
    /// </summary>
    public Uri? BaseURI { get; set; }

    /// <summary>
    /// The endpoint for SessionInformation.
    /// </summary>
    public string? SessionInformation { get; set; } 
}
