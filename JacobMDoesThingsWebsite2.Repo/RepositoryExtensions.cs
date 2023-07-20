namespace JacobMDoesThingsWebsite2.Repo;

/// <summary>
/// Extension methods for building the repository.
/// </summary>
public static class RepositoryExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder">The <see cref="ModelBuilder"/>.</param>
    /// <param name="containerName">The name of the container.</param>
    /// <param name="configure">The entity configuration.</param>
    /// <param name="ignoreDefaultConfig">Sets a flag indicating whether or not default configuration should also be used.</param>
    /// <returns>A completed<see cref="ModelBuilder"/> for the provided entity.</returns>
    public static ModelBuilder ConfigureEntityDefault<T>(this ModelBuilder builder,
                                                      string containerName,
                                                      Action<EntityTypeBuilder<T>>? configure = default,
                                                      bool ignoreDefaultConfig = default)
        where T : BaseEntity
    { 
        var entityBuilder = builder.Entity<T>();
        if (!ignoreDefaultConfig)
        {
            entityBuilder.ConfigureDefaultProperties(containerName);
        }

        configure?.Invoke(entityBuilder);
        return builder;
    }

    public static EntityTypeBuilder<T> ConfigureDefaultProperties<T>(this EntityTypeBuilder<T> entityTypeBuilder,
                                                                     string containerName)
        where T : BaseEntity
    { 
        entityTypeBuilder.ToContainer(containerName);
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Id).ToJsonProperty("id").ValueGeneratedOnAdd();
        entityTypeBuilder.Property(e => e.Type);
        entityTypeBuilder.HasPartitionKey(e => e.PartitionKey);
        entityTypeBuilder.Property(e => e.PartitionKey).ValueGeneratedOnAdd();
        entityTypeBuilder.Property(e => e.CreatedOn).ValueGeneratedOnAdd();
        entityTypeBuilder.Property(e => e.Etag).IsETagConcurrency();
        entityTypeBuilder.Property(e => e.UpdatedOn).ValueGeneratedOnAddOrUpdate();
        entityTypeBuilder.HasDiscriminator(e => e.Type);

        return entityTypeBuilder;
    }

    public static void RemoveBaseMetadataFromUpdate<T>(this EntityEntry<T> entityEntry)
        where T : BaseEntity
    {
        entityEntry.Property(x => x.Id).IsModified = false;
        entityEntry.Property(x => x.PartitionKey).IsModified = false;
        entityEntry.Property(x => x.Type).IsModified = false;
        entityEntry.Property(x => x.CreatedOn).IsModified = false;
        entityEntry.Property(x => x.UpdatedOn).IsModified = false;
        entityEntry.Property(x => x.Etag).IsModified = false;
    }
}