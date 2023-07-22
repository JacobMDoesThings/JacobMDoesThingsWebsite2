namespace JacobMDoesThingsWebsite2.Web;

/// <summary>
/// This class contains constants that are used throughout the application to allow
/// for consistency and better maintainability. Use things like: URIs, Image Locations and Names here.
/// </summary>
public static class WebConstants
{
    private const string _documentationBase = "/Documentation";
    private const string _demosBase = "/Demos";
    private const string _authZAuthNBase = "/AuthZAuthN";
    private const string _uxuiBase = "/UXUI";
    private const string _siteDemoBase = "/SiteDemos";
    private const string _dataCollectionBase = "/DataCollection";
    private const string _apiClientBase = "/ApiClient";
    private const string _oDataApiBase = "/ODataApi";
    private const string _imagesBase = "/images";
    private const string _microsoftIdentityBase = "/MicrosoftIdentity";
    private const string _accountBase = "/Account";

    /// <summary>
    /// The authorization scheme for the B2CApi.
    /// </summary>
    public const string B2CApiScheme = "AzureAdB2CApi";

    /// <summary>
    /// The Base URL For displaying.
    /// </summary>
    public const string WebsiteURL = "JacobMDoesThings.com";

    /// <summary>
    /// The full name of the organization.
    /// </summary>
    public const string WebName = "Jacob M Does Things";

    /// <summary>
    /// The short name of the organization.
    /// </summary>
    public const string ShortWebName = "JMDT";

    /// <summary>
    /// The main logo of the organization. (Name and Logo)
    /// </summary>
    public const string MainLogo = $"{_imagesBase}/MainLogo.png";

    /// <summary>
    /// The simple or small logo of the organization. (Just logo)
    /// </summary>
    public const string SimpleLogo = $"{_imagesBase}/SimpleLogo.png";

    /// <summary>
    /// The URI endpoint for Identity signout.
    /// </summary>
    public const string LogoutURI = $"{_microsoftIdentityBase}{_accountBase}/Signout";

    /// <summary>
    /// The URI endpoint for Identity signin.
    /// </summary>
    public const string SigninURI = $"{_microsoftIdentityBase}{_accountBase}/SignIn";

    /// <summary>
    /// The base URI /
    /// </summary>
    public const string HomeURI = "/";

    /// <summary>
    /// The URI for the Documentation main endpoint.
    /// </summary>
    public const string DocumentationURI = _documentationBase;

    /// <summary>
    /// The URI for the Demos main endpoint.
    /// </summary>
    public const string DemosURI = _demosBase;

    /// <summary>
    /// The URI for the RequireAuthentication Documentation endpoint.
    /// <see cref="Documentation_AuthZAuthN_RequireAuthentication"/>
    /// </summary>
    public const string AuthZAuthNRequireAuthenticationURI = $"{_documentationBase}{_authZAuthNBase}/RequireAuthentication";

    /// <summary>
    /// The URI for the OptionaAuthenticationWithIdentity Documentation endpoint.
    /// <see cref="Documentation_AuthZAuthN_OptionalAuthenticationWithIdentity"/>
    /// </summary>
    public const string AuthZAuthNOptionAuthenticationWithIdentityURI = $"{_documentationBase}{_authZAuthNBase}/OptionalAuthenticationWithIdentity";

    /// <summary>
    /// The URI for the ConfigureAppCSForAuthzAuthn Documentation endpoint.
    /// </summary>
    public const string AuthZAuthNConfigureAppCSURI = $"{_documentationBase}{_authZAuthNBase}/ConfigureAppCSForAuthzAuthn";

    /// <summary>
    /// The URI for the BlazorPageAndComponentAuthorization endpoint.
    /// </summary>
    public const string AuthZAuthNBlazorPageAndComponentAuthorizationURI = $"{_documentationBase}{_authZAuthNBase}/BlazorPageAndComponentAuthorization";

    /// <summary>
    /// The URI for the PolicyBasedAuthorization endpoint.
    /// </summary>
    public const string AuthZAuthNPoliciesURI = $"{_documentationBase}{_authZAuthNBase}/PolicyBasedAuthorization";

    /// <summary>
    /// The URI for the JMDTSideBar documentation endpoint.
    /// <see cref="SideNav"/> and <see cref="DocumentationNavigationItems"/>
    /// </summary>
    public const string UXUIJMDTSideBarURI = $"{_documentationBase}{_uxuiBase}/JMDTSideBar";

    /// <summary>
    /// The URI for the JMDTAppBar documentation endpoint.
    /// <see cref="Documentation_UXUI_JMDTAppBar"/>
    /// </summary>
    public const string UXUIJMDTAppBarURI = $"{_documentationBase}{_uxuiBase}/JMDTAppBar";

    /// <summary>
    /// The URI for the BaseViewModel and BasePage documentation endpoint.
    /// <see cref="BaseViewModel"/> and <see cref="BasePage{T}"/>
    /// </summary>
    public const string UXUIJMDTBaseVMBasePageURI = $"{_documentationBase}{_uxuiBase}/BaseVMBasePage";

    /// <summary>
    /// The URI for the UI ConsentManagement documentation endpoint.
    /// </summary>
    /// <remarks>
    /// <see cref="PrivacyDialog"/>
    /// </remarks>
    public const string DataCollectionConsentManagementUIURI = $"{_documentationBase}{_dataCollectionBase}/ConsentManagement";

    /// <summary>
    /// The URI for the <see cref="DataCollectionConsentManagerURI"/> documentation endpoint.
    /// </summary>
    public const string DataCollectionConsentManagerURI = $"{_documentationBase}{_dataCollectionBase}/ConsentManager";

    /// <summary>
    /// The URI for the <see cref="DataCollectionService"/> documentation endpoint.
    /// </summary>
    public const string DataCollectionDataCollectionServiceURI = $"{_documentationBase}{_dataCollectionBase}/DataCollectionService";

    /// <summary>
    /// The URI for the <see cref="ISessionUploadSchedulerService{T}" <seealso cref="SessionUploadSchedulerService"/> documentation endpoint./>
    /// </summary>
    public const string DataCollectionSessionUploadSchedulerServiceURI = $"{_documentationBase}{_dataCollectionBase}/SessionUploadSchedulerService";

    /// <summary>
    /// The URI for the <see cref="ServiceOdataServiceCaller"/> documentation endpoint.
    /// </summary>
    public const string ApiClientOdataServiceCallerURI = $"{_documentationBase}{_apiClientBase}/OdataServiceCaller";

    /// <summary>
    /// The URI for the <see cref="UserAuthorizationHandler"/> documentation endpoint.
    /// </summary>
    public const string ApiClientUserAuthorizationHandlerURI = $"{_documentationBase}{_apiClientBase}/UserAuthHandler";

    /// <summary>
    /// The URI for the <see cref="ServiceAuthorizationHandler"/> documentation endpoint.
    /// </summary>
    public const string ApiClientServiceAuthorizationHandlerURI = $"{_documentationBase}{_apiClientBase}/ServiceAuthHandler";

    /// <summary>
    /// The URI for the <see cref="BaseController"/> and <see cref="SessionInformationController"/> documentation endpoint.
    /// </summary>
    public const string ODataApiControllersURI = $"{_documentationBase}{_oDataApiBase}/Controllers";

    /// <summary>
    /// Shows demonstrations involving the data collection on this site.
    /// </summary>
    public const string SiteDemoDataCollectionURI = $"{_demosBase}{_siteDemoBase}/DataCollection";

    
    /// <summary>
    /// The root routes in which the sidebar should be visible. <see cref="SideNav"/>
    /// </summary>
    public readonly static HashSet<string> SidebarEnabledRoutes = new()
    {
        DocumentationURI,
        DemosURI
    };

    /// <summary>
    /// The URIs of the available routes for the Appbar <see cref="AppBar"/>
    /// </summary>
    public readonly static HashSet<string> AppbarNavItems = new()
    { 
        HomeURI,
        DocumentationURI,
        DemosURI
    };

    /// <summary>
    /// The URIs of the available routes for the <see cref="SideNav"/> when the root of the URI is 
    /// for Documentation. <seealso cref="DocumentationNavigationItems"/>
    /// </summary>
    public readonly static HashSet<string> DocumentationNavItems = new()
    {
        DocumentationURI,
        AuthZAuthNRequireAuthenticationURI,
        AuthZAuthNOptionAuthenticationWithIdentityURI,
        AuthZAuthNConfigureAppCSURI,
        AuthZAuthNBlazorPageAndComponentAuthorizationURI,
        AuthZAuthNPoliciesURI,
        UXUIJMDTSideBarURI,
        UXUIJMDTBaseVMBasePageURI,
        UXUIJMDTAppBarURI,
        DataCollectionConsentManagementUIURI,
        DataCollectionConsentManagerURI,
        DataCollectionSessionUploadSchedulerServiceURI,
        DataCollectionDataCollectionServiceURI,
        ApiClientOdataServiceCallerURI,
        ApiClientUserAuthorizationHandlerURI,
        ApiClientServiceAuthorizationHandlerURI,
        ODataApiControllersURI
    };

    /// <summary>
    /// The URIs of the available routes for the <see cref="SideNav"/> when the root of the URI is
    /// for Demos. <seealso cref="DemosNavigationItems"/>
    /// </summary>
    public readonly static HashSet<string> DemosNavItems = new()
    {
        DemosURI,
        SiteDemoDataCollectionURI,
    };
}
