namespace JacobMDoesThingsWebsite2.Web.ViewModels;

/// <summary>
/// Viewmodel for the state and behavior of the <see cref="SideNav"/>.
/// </summary>
public class SideNavVM : BaseViewModel
{
    private bool _authZAuthNToggle;
    private bool _siteDemosToggle;
    private bool _uIUXToggle;
    private bool _dataCollectionToggle;
    private bool _apiClientToggle;
    private string _currentLocation = string.Empty;
    private bool _showSideBar = false;

    public enum SideNavType
    {
        DocumentationSideNav,
        DemoSideNav
    }

    /// <summary>
    /// Gets or sets the CurrentLocation (URI)
    /// </summary>
    public string CurrentLocation
    {
        get
        {
            return _currentLocation;
        }
        set
        {
            _currentLocation = value;
            
            var endingIndex = !CurrentLocation.Contains('/') ? CurrentLocation.Length  : CurrentLocation.IndexOf('/');    
            var currentLocation = $"/{CurrentLocation[..endingIndex].Trim('/')}";
            switch (currentLocation)
            {
                case DocumentationURI:
                    CurrentSideNav = SideNavType.DocumentationSideNav;
                    break;
                case DemosURI:
                    CurrentSideNav = SideNavType.DemoSideNav;
                    break;
            }

            OnPropertyChanged();
        }
    }

    /// <summary>
    /// The current side navigation items component that should be displayed.
    /// </summary>
    public SideNavType CurrentSideNav { get; set; }

    /// <summary>
    /// Gets a value indicating whether the CurrentLocation is in a route that should show the <see cref="SideNav"/>
    /// </summary>
    /// <returns></returns>
    public bool IsInSidebarEnabledRoute()
    {
        return CurrentLocation.IsInSideBarEnabledRoutes();
    }

    /// <summary>
    /// Gets or sets a value indicating the visibility of the <see cref="SideNav"/>.
    /// </summary>
    public bool ShowSideBar 
    {
        get 
        {
            return _showSideBar;
        }
        set
        { 
            _showSideBar= value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets a value indicating the state of the Toggle for the AuthZAuthN sub-menu.
    /// </summary>
    public ref bool AuthZAuthNToggle
    {
        get
        {
            return ref _authZAuthNToggle;
        }
    }

    /// <summary>
    /// Gets a value indicating the state of the Toggle for the Site Demos sub-menu.
    /// </summary>
    public ref bool SiteDemosToggle
    {
        get
        {
            return ref _siteDemosToggle;
        }
    }

    /// <summary>
    /// Gets a value indicating the state of the Toggle for the UIUX sub-menu.
    /// </summary>
    public ref bool UIUXToggle
    {
        get
        {
            return ref _uIUXToggle;
        }
    }

    /// <summary>
    /// Gets a value indicating the state of the Toggle for the DataCollection sub-menu.
    /// </summary>
    public ref bool DataCollectionToggle
    {
        get
        {
            return ref _dataCollectionToggle;
        }
    }

    /// <summary>
    /// Gets a value indicating the state of the Toggle for the ApiClient sub-menu.
    /// </summary>
    public ref bool ApiClientToggle
    {
        get 
        {
            return ref _apiClientToggle;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not a menu item is focused, this is helpful when handling
    /// events to determine if or when the sidenav should be minimized or hidden.
    /// </summary>
    public bool IsFocusedOnMenuItem { get; set; } = false;

    /// <summary>
    /// Reverses the current value for the visibility of the sidebar and removes focus.
    /// </summary>
    public void ToggleSideBar()
    {
        ShowSideBar = !ShowSideBar;
        IsFocusedOnMenuItem = false;
    }

    /// <summary>
    /// Reverses the state of the <see cref="bool"/> for the toggle.
    /// </summary>
    /// <param name="toggleItem">Reference of the toggle.</param>
    public void ToggleMenuItem(ref bool toggleItem)
    {
        toggleItem = !toggleItem;
    }
}
