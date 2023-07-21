namespace JacobMDoesThingsWebsite2.Web.Configuration;

internal static class CompositionRoot
{

    /// <summary>
    /// Configures base services.
    /// </summary>
    /// <param name="services">The ServiceCollection.</param>
    /// <param name="configuration">The appsettings configuration.</param>
    /// <returns><see cref="ServiceCollection"/> with configured services.</returns>
    internal static IServiceCollection ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .AddScoped<SideNavVM>()
            .ConfigureAppSettings(configuration)
            .ConfigureClientTokenAcquisition()
            .AddOdataClient()
            .AddScoped<IConsentServiceManager, LocalStorageService>()
            .AddScoped<CircuitHandler, DataCollectionService>()        
            .ConfigureSecurity(configuration);
        services.AddRazorPages();
        services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();

        return services;
    }

    /// <summary>
    /// Configure token acquisition for b2c client_credentials flow.
    /// </summary>
    /// <param name="services">The ServiceCollection.</param>
    /// <returns><see cref="ServiceCollection"/> with configured services.</returns>
    private static IServiceCollection ConfigureClientTokenAcquisition(this IServiceCollection services)
    {
        services.AddSingleton<ServiceTokenAcquirer>()
            .AddTransient<ServiceAuthorizationHandler>()
            .AddHttpClient<IServiceODataServiceCaller, ServiceOdataServiceCaller>().AddHttpMessageHandler<ServiceAuthorizationHandler>();
        return services;
    }

    /// <summary>
    /// Requires ConfigureServices and configures security for the application.
    /// </summary>
    /// <param name="services">The ServiceCollection.</param>
    /// <param name="configuration">The appsettings configuration.</param>
    /// <returns><see cref="ServiceCollection"/>with configured security services.</returns>
    private static IServiceCollection ConfigureSecurity(this IServiceCollection services, ConfigurationManager configuration)
    {
        // This is required to be instantiated before the OpenIdConnectOptions starts getting configured.
        // By default, the claims mapping will map claim names in the old format to accommodate older SAML applications.
        // 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role' instead of 'roles'
        // This flag ensures that the ClaimsIdentity claims collection will be built from the claims in the token.
        JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        });

        services.AddAuthentication()
            .AddMicrosoftIdentityWebApp(configuration, nameof(B2CClient))
            .EnableTokenAcquisitionToCallDownstreamApi(configuration.GetRequiredSection(nameof(B2CClient)).Get<B2CClient>()!.UserScopes)
            .AddInMemoryTokenCaches();

        services.AddAuthentication()
            .AddMicrosoftIdentityWebApi(
                configuration, nameof(B2CClient), B2CApiScheme)
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddInMemoryTokenCaches();

        services.AddControllersWithViews().AddMicrosoftIdentityUI();

        return services;
    }

    /// <summary>
    /// Builds and adds Odata client.
    /// </summary>
    /// <param name="services">The ServiceCollection</param>
    /// <returns><see cref="ServiceCollection"/> with configured Odata Service.</returns>
    private static IServiceCollection AddOdataClient(this IServiceCollection services)
    {
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntityType<PageVisitDTO>().HasKey(entity => entity.Id);
        modelBuilder.EntityType<PageVisitDTO>().Property(entity => entity.Id).IsNullable();
        var sessionInformations = modelBuilder.EntitySet<SessionInformationDTO>("SessionInformation");
        modelBuilder.EntityType<SessionInformationDTO>().HasKey(entity => entity.Id);
        modelBuilder.EntityType<SessionInformationDTO>().Property(entity => entity.Id).IsNullable();
        modelBuilder.EntityType<SessionInformationDTO>().HasMany(e => e.PageVisits);
        modelBuilder.EntityType<PageVisitDTO>().Property(entity => entity.Id).IsNullable();

        services.AddControllers().AddOData(
            options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
                "odata/v1",
                modelBuilder.GetEdmModel()));

        services.AddAutoMapper(typeof(SessionInformationProfile));
        return services;
    }

    /// <summary>
    /// Binds App
    /// </summary>
    /// <param name="configurationRoot"></param>
    /// <returns></returns>
    private static IServiceCollection ConfigureAppSettings(this IServiceCollection services, IConfigurationRoot configurationRoot)
    {
        AppSettings settings = new()
        {
            OdataServiceCallerOptions = configurationRoot.GetRequiredSection(nameof(OdataServiceCallerOptions)).Get<OdataServiceCallerOptions>(),
            StartUploadSessionsServiceOptions = configurationRoot.GetRequiredSection(nameof(StartUploadSessionsServiceOptions)).Get<StartUploadSessionsServiceOptions>(),
            CosmosRepositoryOptions = configurationRoot.GetRequiredSection(nameof(CosmosDBOptions)).Get<CosmosDBOptions>(),
            JacobMDoesThingsWebsite2ContextOptions = configurationRoot.GetRequiredSection(nameof(JacobMDoesThingsWebsite2ContextOptions)).Get<JacobMDoesThingsWebsite2ContextOptions>(),
            B2CClient = configurationRoot.GetRequiredSection(nameof(B2CClient)).Get<B2CClient>()
        };

        _ = settings.OdataServiceCallerOptions ?? throw new NullReferenceException(nameof(settings.OdataServiceCallerOptions));
        _ = settings.StartUploadSessionsServiceOptions ?? throw new NullReferenceException(nameof(settings.StartUploadSessionsServiceOptions));
        _ = settings.CosmosRepositoryOptions ?? throw new NullReferenceException(nameof(settings.CosmosRepositoryOptions));
        _ = settings.B2CClient ?? throw new NullReferenceException(nameof(settings.B2CClient));
        _ = settings.JacobMDoesThingsWebsite2ContextOptions ?? throw new NullReferenceException(nameof(settings.JacobMDoesThingsWebsite2ContextOptions));

        services
            .AddCosmosClient(settings.CosmosRepositoryOptions)
            .AddSingleton(settings.B2CClient)
            .AddSingleton(settings.StartUploadSessionsServiceOptions)
            .AddSingleton(settings.OdataServiceCallerOptions)
            .AddSingleton(settings.JacobMDoesThingsWebsite2ContextOptions);

        return services;
    }
}