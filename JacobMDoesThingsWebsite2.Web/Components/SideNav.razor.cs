namespace JacobMDoesThingsWebsite2.Web.Components;

/// <summary>
/// Codebehind for SideNav.razor.
/// </summary>
public partial class SideNav : BasePage<SideNavVM>
{
    /// <summary>
    /// Gets or sets the <see cref="NavigationManager"/>
    /// </summary>
    [Inject]
    NavigationManager? NavigationManager { get; set; }

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        if (NavigationManager is not null)
        {
            VM!.CurrentLocation = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            NavigationManager.LocationChanged += (o, e) =>
            {
                VM!.CurrentLocation = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);

            };
        }

        base.OnInitialized();
    }
}

