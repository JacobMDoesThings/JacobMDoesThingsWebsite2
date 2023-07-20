namespace JacobMDoesThingsWebsite2.Repo.Configuration;

public class JacobMDoesThingsWebsite2ContextOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JacobMDoesThingsWebsite2ContextOptions"/> class.
    /// </summary>
    /// <param name="sessionInformationContainerName">SessionInformation Container Name.</param>
    public JacobMDoesThingsWebsite2ContextOptions(string sessionInformationContainerName)
    {
        if(string.IsNullOrEmpty(sessionInformationContainerName)) throw new ArgumentNullException(nameof(sessionInformationContainerName));
        SessionInformationContainerName = sessionInformationContainerName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="JacobMDoesThingsWebsite2ContextOptions"/> class.
    /// Parameterless Constructor.
    /// </summary>
    public JacobMDoesThingsWebsite2ContextOptions()
    {
    }

    /// <summary>
    /// Gets or sets the name of the SessionInformation container name.
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public string SessionInformationContainerName { get; set; } = string.Empty;
}
