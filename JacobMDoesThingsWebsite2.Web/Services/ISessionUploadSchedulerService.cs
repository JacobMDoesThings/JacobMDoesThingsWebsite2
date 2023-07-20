namespace JacobMDoesThingsWebsite2.Web.Services;

/// <summary>
/// Interface for adding sessioninformation to a collection. 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISessionUploadSchedulerService<T>
    where T : class
{
    /// <summary>
    /// Adds type representing session information with a unique id.
    /// </summary>
    /// <param name="sessionId">The unique Id.</param>
    /// <param name="sessionInfo">The session information.</param>
    public void AddSessionInformationTask(string sessionId, T sessionInfo);
}
