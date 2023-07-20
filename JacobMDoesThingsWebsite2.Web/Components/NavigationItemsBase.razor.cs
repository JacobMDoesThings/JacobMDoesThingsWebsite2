namespace JacobMDoesThingsWebsite2.Web.Components;

/// <summary>
/// The codebehind for NavigationItemsBase.razor."/>
/// </summary>
public partial class NavigationItemsBase : BasePage<SideNavVM>
{
    private string _currentURI = string.Empty;
    private const string _bgColor = "bg-gray-700";
    protected readonly Dictionary<string, string> LinkCss = new();

    /// <summary>
    /// Gets or sets the <see cref="NavigationManager"/>.
    /// </summary>
    [Parameter]
    public NavigationManager? NavigationManager { get; set; }


    /// <summary>
    /// Gets or sets the Current URI the views in on.
    /// </summary>
    [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
    public string CurrentURI
#pragma warning restore BL0007 // Component parameters should be auto properties
    {
        get
        {
            return _currentURI;
        }
        set
        {
            _currentURI = value;
            SetLinkBGs(GetNavigationItems());
        }
    }

    private static string GetCharsAfterLastInstanceOfDelimiter(string str, char delim)
    {
        if (!string.IsNullOrWhiteSpace(str))
        {
            int charLocation = str.LastIndexOf(delim);

            return charLocation > 0 ? str[charLocation..] : str;
        }

        return string.Empty;
    }

    private HashSet<string> GetNavigationItems()
    {
        HashSet<string> returnSet = new();

        if (CurrentURI.StartsWith(DocumentationURI.Trim('/')))
        {
            returnSet = DocumentationNavItems;
        }
        else if (CurrentURI.StartsWith(DemosURI.Trim('/')))
        { 
            returnSet = DemosNavItems;  
        }

        return returnSet;
    }

    private void SetLinkBGs(HashSet<string> set)
    {
        string area = GetCharsAfterLastInstanceOfDelimiter(CurrentURI, '/');

        foreach (string uri in set)
        {

            LinkCss[uri] = CurrentURI.Equals(uri.TrimStart('/'), StringComparison.OrdinalIgnoreCase) ? _bgColor : string.Empty;
        }

        InvokeAsync(StateHasChanged);
    }
}
