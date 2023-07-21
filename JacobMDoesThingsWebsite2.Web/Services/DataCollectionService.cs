namespace JacobMDoesThingsWebsite2.Web.Services;

/// <summary>
/// Service for collection user data such as interaction and user agent.
/// </summary>
public class DataCollectionService : CircuitHandler
{
    private readonly IJSRuntime _runtime;
    private readonly string _uniqueUserTrackingId = Guid.NewGuid().ToString();
    private readonly NavigationManager _navigationManager;
    private readonly ISessionUploadSchedulerService<SessionInformationDTO> _sessionUploadSchedulerService;
    private readonly SessionInformationDTO _sessionInformation = new();
    private readonly IConsentServiceManager _localStorageService;

    /// <summary>
    /// Initializer for the DataCollectionService"/>
    /// </summary>
    /// <param name="navigationManager">The <see cref="NavigationManager"/> for Blazor navigation.</param>
    /// <param name="scheduler">The service for managing collected data <see cref="ISessionUploadSchedulerService{T}"/></param>
    /// <param name="localStorageService">Consent manager for dictating allowable collected data <see cref="IConsentServiceManager"/></param>
    public DataCollectionService(NavigationManager navigationManager, ISessionUploadSchedulerService<SessionInformationDTO> scheduler,
        IConsentServiceManager localStorageService, IJSRuntime jSRuntime)
    {
        _runtime = jSRuntime;
        _navigationManager = navigationManager;
        _navigationManager.LocationChanged += NavigationManagerLocationChangeHandler;
        _sessionUploadSchedulerService = scheduler;
        _localStorageService = localStorageService;
        _localStorageService.PropertyChanged += OnSessionIdChangedAsync;
        _sessionInformation.PageVisits.Add(new PageVisitDTO()
        {
            URI = _navigationManager.ToBaseRelativePath(_navigationManager.Uri),
            StartTime = DateTime.Now
        });
    }

    /// <summary>
    /// Handle data collection triggered by Navigation changes in the <see cref="NavigationManager"/>
    /// </summary>
    /// <param name="sender">The requester.</param>
    /// <param name="e">The args <see cref="EventArgs"/></param>
    protected void NavigationManagerLocationChangeHandler(object? sender, EventArgs e)
    {
        var endpoint = _navigationManager.ToBaseRelativePath(_navigationManager.Uri);
        _sessionInformation.PageVisits.Last().EndTime = DateTimeOffset.Now;
        _sessionInformation.PageVisits.Add(new PageVisitDTO()
        {
            URI = endpoint,
            StartTime = DateTimeOffset.Now
        });
    }

    // Information found here https://stackoverflow.com/questions/61345537/detect-client-closing-connection-blazor
    ///<inheritdoc/>
    public override async Task OnConnectionDownAsync(Circuit circuit,
        CancellationToken cancellationToken)
    {
        if (_sessionInformation.PageVisits.Count > 0)
        {
            _sessionInformation.PageVisits.Last().EndTime = DateTimeOffset.Now;
        }

        _sessionUploadSchedulerService.AddSessionInformationTask(_uniqueUserTrackingId ?? string.Empty, _sessionInformation);

        await base.OnConnectionDownAsync(circuit, cancellationToken);
    }

    ///<inheritdoc/>
    public override async Task OnConnectionUpAsync(Circuit circuit,
        CancellationToken cancellationToken)
    {
        _sessionInformation.TrackingId = await _localStorageService.GetSessionIdAsync();
        _sessionInformation.UserAgent = await _runtime.InvokeAsync<string>("getUserAgent");
        await base.OnConnectionUpAsync(circuit, cancellationToken);
    }

    private async void OnSessionIdChangedAsync(object? sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == nameof(LocalStorageService.GetSessionIdAsync))
        {
            _sessionInformation.TrackingId = (await _localStorageService.GetSessionIdAsync());
        }
    }
}
