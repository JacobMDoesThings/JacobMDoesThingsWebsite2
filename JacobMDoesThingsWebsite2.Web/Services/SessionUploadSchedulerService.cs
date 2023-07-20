namespace JacobMDoesThingsWebsite2.Web.Services;

/// <summary>
/// Service for managing the uploads of completed sessions on a timer.
/// </summary>
public class SessionUploadSchedulerService : ISessionUploadSchedulerService<SessionInformationDTO>
{
    private readonly IServiceODataServiceCaller _sessionFunctionsCaller;
    private readonly Dictionary<string, SessionInformationDTO> _sessionsReadyForUpload = new();
    private readonly StartUploadSessionsServiceOptions _sUSSoptions;

    /// <summary>
    /// Initializes SessionUploadSchedulerService.
    /// </summary>
    /// <param name="service">The <see cref="IServiceODataServiceCaller"/> for saving the data.</param>
    /// <param name="SUSSoptions">The <see cref="StartUploadSessionsServiceOptions"/>. </param>
    public SessionUploadSchedulerService(IServiceODataServiceCaller service, StartUploadSessionsServiceOptions SUSSoptions)
    {
        _sessionFunctionsCaller = service;
        _sUSSoptions = SUSSoptions;
        StartUploadSessionsService();
    }

    /// <summary>
    /// Adds a new <see cref="SessionInformationDTO"/> to a list to be managed by the service.
    /// </summary>
    /// <param name="sessionId">Must be a unique key representing the session.</param>
    /// <param name="sessionInformationDTO">The <see cref="SessionInformationDTO"/> to be saved.</param>
    public void AddSessionInformationTask(string sessionId, SessionInformationDTO sessionInformationDTO)
    {
        _sessionsReadyForUpload.TryAdd(sessionId, sessionInformationDTO);
    }

    private void StartUploadSessionsService()
    {
        var autoEvent = new AutoResetEvent(true);

        Timer intervalTimer = new(async (object? objectStatus) =>
        {
            foreach (KeyValuePair<string, SessionInformationDTO> kvp in _sessionsReadyForUpload)
            {
                await _sessionFunctionsCaller.PostSessionInformationAsync(kvp.Value);
            }

            _sessionsReadyForUpload.Clear();

        }, autoEvent, _sUSSoptions.DueTime, _sUSSoptions.IntervalTime);
    }
}
