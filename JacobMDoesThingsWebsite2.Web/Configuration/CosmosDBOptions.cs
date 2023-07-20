namespace JacobMDoesThingsWebsite2.Web.Configuration;

/// <summary>
/// The options for the CosmosRepository.
/// Required for configuration.
/// </summary>
public class CosmosDBOptions
{
    /// <summary>
    /// The Cosmos endpoint.
    /// </summary>
    public string EndPoint { get; set; } = string.Empty;

    /// <summary>
    /// The account key for Cosmos.
    /// </summary>
    public string AccountKey { get; set; } = string.Empty;

    /// <summary>
    /// The Cosmos database name.
    /// </summary>
    public string DatabaseName { get; set; } = string.Empty;
}
