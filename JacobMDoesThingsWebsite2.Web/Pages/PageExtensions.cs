namespace JacobMDoesThingsWebsite2.Web.Pages;

public static class PageExtensions
{
    /// <summary>
    /// Determine if location is in SideBarEnabledRoutes.
    /// </summary>
    /// <param name="value">A string URI representing the location.</param>
    /// <returns>A value representing whether or not this is a side bar enabled route.</returns>
    /// <remarks>Requires Collection in WebConstants.</remarks>
    public static bool IsInSideBarEnabledRoutes(this string value)
    {
        foreach (var uri in SidebarEnabledRoutes)
        {
            if ($"/{value}".StartsWith(uri, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}
