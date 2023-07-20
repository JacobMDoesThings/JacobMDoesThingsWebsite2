namespace JacobMDoesThingsWebsite2.Web.Configuration;

internal static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configure the CosmosClient.
    /// </summary>
    /// <param name="services">Service Collection</param>
    /// <param name="options">RepositoryOptions.</param>
    /// <returns><see cref="IServiceCollection"/>with CosmosClient configuration.</returns>
    internal static IServiceCollection AddCosmosClient(this IServiceCollection services, CosmosDBOptions options)
    {
        if (string.IsNullOrEmpty(options.EndPoint) ||
            string.IsNullOrEmpty(options.AccountKey) ||
            string.IsNullOrEmpty(options.DatabaseName)) 
        {
            throw new ArgumentException($"{nameof(options.EndPoint)}, {nameof(options.AccountKey)}, " +
                $"{nameof(options.DatabaseName)} must be all not null and not empty.");
        }
 
        services.AddDbContext<JacobMDoesThingsWebsite2Context>(o =>
        o.UseCosmos(options.EndPoint, options.AccountKey, options.DatabaseName), ServiceLifetime.Transient, ServiceLifetime.Singleton);
        return services;

    }
}
