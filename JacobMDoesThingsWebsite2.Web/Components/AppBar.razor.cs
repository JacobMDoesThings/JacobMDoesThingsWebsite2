namespace JacobMDoesThingsWebsite2.Web.Components;

/// <summary>
/// Code behind for AppBar.razor.
/// </summary>
public partial class AppBar
{
    /// <summary>
    /// Gets or sets the <see cref="NavigationManager"/>.
    /// </summary>
    [Inject]
    NavigationManager? NavigationManager { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="AuthenticationStateProvider"/>.
    /// </summary>
    [Inject]
    AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

    private bool _menuVisible = false;
    private bool _profileMenuVisible = false;
    private bool _notificationMenuVisible = false;
    private const string _bgColor = "bg-gray-800";
    private readonly Dictionary<string, string> _linkCss = new();
    private string _currentZone = string.Empty;

    private string _userInitials = string.Empty;

    private string UserInitials
    {
        get => _userInitials;
        set
        {
            _userInitials = value;
            InvokeAsync(StateHasChanged);
        }
    }

    ///<inheritdoc/>
    protected override async Task OnInitializedAsync()
    {
        UserInitials = (await AuthenticationStateProvider!.GetAuthenticationStateAsync()).UserInitials();
        AuthenticationStateProvider.AuthenticationStateChanged += AuthenticationStateChangedHandler;
        NavigationManager!.LocationChanged += (o, e) => SetLinkBGs();

        SetLinkBGs();
    }

    private static string CurrentZone(NavigationManager navigationManager)
    {
        var check = GetCharsBeforeFirstInstanceOfDelimiter(navigationManager!.ToBaseRelativePath(navigationManager.Uri), '/');
        return check;
    }

    private static string GetCharsBeforeFirstInstanceOfDelimiter(string str, char delim)
    {
        if (!string.IsNullOrWhiteSpace(str))
        {
            int charLocation = str.IndexOf(delim, StringComparison.OrdinalIgnoreCase);

            return charLocation > 0 ? str[..charLocation] : str;
        }

        return string.Empty;
    }

    private void SetLinkBGs()
    {
        _currentZone = CurrentZone(NavigationManager!);
        string area = $"/{_currentZone}";

        foreach (string uri in AppbarNavItems)
        {
            _linkCss[uri] = area.Equals(uri, StringComparison.OrdinalIgnoreCase) ? _bgColor : string.Empty;
        }

        InvokeAsync(StateHasChanged);
    }

    private async void AuthenticationStateChangedHandler(Task<AuthenticationState> task)
    {
        var authState = await (task);
        UserInitials = authState.UserInitials(2);
    }

    private void ToggleMenu()
    {
        _menuVisible = !_menuVisible;
    }

    private void ToggleProfileMenu()
    {
        _profileMenuVisible = !_profileMenuVisible;
    }

    private void ToggleNotificationMenu()
    {
        _notificationMenuVisible = !_notificationMenuVisible;
    }
}
