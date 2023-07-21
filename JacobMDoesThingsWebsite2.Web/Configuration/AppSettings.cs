namespace JacobMDoesThingsWebsite2.Web.Configuration;

/// <summary>
/// Application settings used for binding during configuration.
/// </summary>
internal class AppSettings
{
    /// <summary>
    /// Gets or sets the <see cref="OdataServiceCallerOptions"/>.
    /// </summary>
    public OdataServiceCallerOptions? OdataServiceCallerOptions { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="CosmosRepositoryOptions"/>
    /// </summary>
    public CosmosDBOptions? CosmosRepositoryOptions { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="JacobMDoesThingsWebsite2ContextOptions"/>.
    /// </summary>
    public JacobMDoesThingsWebsite2ContextOptions? JacobMDoesThingsWebsite2ContextOptions { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="B2CClient"/> for handling client credential auth.
    /// </summary>
    public B2CClient? B2CClient { get; set; }

}
