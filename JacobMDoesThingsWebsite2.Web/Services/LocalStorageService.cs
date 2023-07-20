namespace JacobMDoesThingsWebsite2.Web.Services;

/// <summary>
/// The service responsible for managing <see cref="ProtectedBrowserStorage"/>
/// </summary>
public class LocalStorageService : IConsentServiceManager
{
    private readonly ProtectedLocalStorage _protectedLocalStorage;
    private readonly string _consentHasBeenRequestedKey = "ConsentHasBeenRequested";
    private readonly string _consentHasBeenGivenKey = "ConsentHasBeenGiven";
    private readonly string _sessionIdKey = "SessionId";

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Initializes LocalStorageService.
    /// </summary>
    /// <param name="localStorage"></param>
    /// <param name="navigationManager"></param>
    public LocalStorageService(ProtectedLocalStorage localStorage)
    {
        _protectedLocalStorage = localStorage;
    }

    ///<inheritdoc/>
    public async Task<bool> GetConsentHasBeenRequestedAsync()
    {
        return (await _protectedLocalStorage.GetAsync<bool>(_consentHasBeenRequestedKey)).Value;
    }

    ///<inheritdoc/>
    public async Task SetConsentHasBeenRequestedAsync()
    {
        await _protectedLocalStorage.SetAsync(_consentHasBeenRequestedKey, true);
        NotifyPropertyChanged(_consentHasBeenRequestedKey);
    }

    ///<inheritdoc/>
    public async Task<bool> GetConsentHasBeenGivenAsync()
    {
        return (await _protectedLocalStorage.GetAsync<bool>(_consentHasBeenGivenKey)).Value;
    }

    ///<inheritdoc/>
    public async Task SetConsentHasBeenGivenAsync(bool value)
    {
        var sessionId = (await _protectedLocalStorage.GetAsync<string>(_sessionIdKey)).Value;

        if (value)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                await SetSessionIdAsync();
            }
        }
        else 
        { 
            await ClearSessionIdAsync();
        }

        await _protectedLocalStorage.SetAsync(_consentHasBeenGivenKey, value);
        NotifyPropertyChanged(_consentHasBeenGivenKey);
    }

    ///<inheritdoc/>
    public async Task<string> GetSessionIdAsync()
    {
        var value = (await _protectedLocalStorage.GetAsync<string>(_sessionIdKey)).Value;
        return value ??= string.Empty;
    }

    ///<inheritdoc/>
    public async Task ClearSessionIdAsync()
    {
        await _protectedLocalStorage.SetAsync(_sessionIdKey, string.Empty);
        NotifyPropertyChanged(nameof(GetSessionIdAsync));
    }

    ///<inheritdoc/>
    private async Task SetSessionIdAsync()
    {        
        await _protectedLocalStorage.SetAsync(_sessionIdKey, Guid.NewGuid());
        NotifyPropertyChanged(nameof(GetSessionIdAsync));
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged is not null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
