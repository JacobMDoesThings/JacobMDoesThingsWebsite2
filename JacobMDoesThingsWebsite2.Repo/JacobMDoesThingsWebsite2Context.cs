namespace JacobMDoesThingsWebsite2.Repo;

/// <summary>
/// DBContext for JacobMDoesThingsWebsite2.
/// </summary>
public class JacobMDoesThingsWebsite2Context : DbContext
{
    private readonly JacobMDoesThingsWebsite2ContextOptions _options;
    private readonly Action<EntityTypeBuilder<SessionInformationEntity>> _configureSessionInformationEntity = (_entityTypeBuilder) =>
    {
        _entityTypeBuilder.Property(e => e.TrackingId);
        _entityTypeBuilder.Property(e => e.UserAgent);
        _entityTypeBuilder.OwnsMany(e => e.PageVisitEntities, pve =>
        {
            pve.HasKey(e => e.Id);
            pve.Property(e => e.Id).ToJsonProperty("id").ValueGeneratedOnAdd();
            pve.Property(e => e.StartTime);
            pve.Property(e => e.EndTime);
            pve.Property(e => e.URI);
            pve.WithOwner().HasForeignKey(e => e.SessionInformationEntityId);
        });
    };

    /// <summary>
    /// Initializes an instance of <see cref="JacobMDoesThingsWebsite2Context"/>.
    /// </summary>
    /// <param name="dbContextOptions">The <see cref="DbContextOptions"/>.</param>
    /// <param name="options">The <see cref="JacobMDoesThingsWebsite2ContextOptions"/>.</param>
    public JacobMDoesThingsWebsite2Context(DbContextOptions dbContextOptions, JacobMDoesThingsWebsite2ContextOptions options)
        : base(dbContextOptions)
    {
        _options = options;
        ChangeTracker.AutoDetectChangesEnabled = true;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    /// <summary>
    /// Builds the repository.
    /// </summary>
    /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ConfigureEntityDefault(_options.SessionInformationContainerName, _configureSessionInformationEntity);
    }
}
