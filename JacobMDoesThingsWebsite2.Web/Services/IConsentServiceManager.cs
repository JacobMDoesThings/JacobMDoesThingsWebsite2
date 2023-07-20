namespace JacobMDoesThingsWebsite2.Web.Services;
/// <summary>
/// Interface for managin user consent on data collection.
/// </summary>
public interface IConsentServiceManager : INotifyPropertyChanged
{
    /// <summary>
    /// Gets a bool indicating whether or not data collection consent has been requested.
    /// </summary>
    /// <returns>A bool indicating whether or not consent has been requested.</returns>
    public Task<bool> GetConsentHasBeenRequestedAsync();

    /// <summary>
    /// Sets the value indicating whether or not consent has been requested to true.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the completion status of the task.</returns>
    public Task SetConsentHasBeenRequestedAsync();

    /// <summary>
    /// Gets a value indicating whether or not Consent to collect data has been given.
    /// </summary>
    /// <returns></returns>
    public Task<bool> GetConsentHasBeenGivenAsync();

    /// <summary>
    /// Sets a value indicating whether or not data collection consent has been given.
    /// </summary>
    /// <param name="value">The value indicating given consent.</param>
    /// <returns>A <see cref="Task"/> representing the completion status of the task.</returns>
    public Task SetConsentHasBeenGivenAsync(bool value);

    /// <summary>
    /// Gets the unique session Id associated with a user's browsesr storage and long running sessions
    /// to track usage across multiple visits.
    /// </summary>
    /// <returns>A <see cref="string" /> value representing the user's session id.</returns>
    public Task<string> GetSessionIdAsync();

    /// <summary>
    /// Sets the session Id of the user to an empty string.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the completion status of the task.</returns>
    public Task ClearSessionIdAsync();
}
