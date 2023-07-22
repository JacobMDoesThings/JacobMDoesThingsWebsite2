namespace JacobMDoesThingsWebsite2.Web.Controllers;

/// <summary>
/// The base <see cref="ODataController"/> for odata controllers.
/// </summary>
public abstract class BaseController : ODataController
{
    private readonly ILogger _logger;
    public readonly DbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes the BaseController.
    /// </summary>
    /// <param name="loggerFactory">The <see cref="ILoggerFactory"/></param>
    /// <param name="context">The <see cref="DbContext"/></param>
    protected BaseController(ILoggerFactory loggerFactory, DbContext context, IMapper mapper)
    {
        _logger = loggerFactory.CreateLogger<BaseController>();
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates and commits single change to the orm.
    /// </summary>
    /// <typeparam name="TDTO">The <see cref="BaseDTO"/> representing the entity.</typeparam>
    /// <typeparam name="TEntity">The <see cref="BaseEntity"/> type to commit/</typeparam>
    /// <param name="dto">A <see cref="BaseDTO"/> to be converted to an entity and created.</param>
    /// <returns><see cref="ActionResult"/>Containing a <see cref="BaseDTO"/> representation of the created entity.</returns>
    protected async Task<ActionResult> PostOneAsync<TDTO, TEntity>(TDTO dto)
    where TDTO : BaseDTO
    where TEntity : BaseEntity
    {
        if (!ModelState.IsValid)
        { 
            return BadRequest(ModelState);
        }

        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Created(_mapper.Map<TDTO>(entity));
        }
        catch (Exception ex)
        {
            _logger.LogError("Error encountered on creating record for entity of type {type}. {exception}", typeof(TEntity).Name, ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Gets a set of <see cref="BaseDTO"/>s representing queried entities.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="BaseEntity"/></typeparam>
    /// <typeparam name="TDTO"><see cref="BaseDTO"/></typeparam>
    /// <returns><see cref="ActionResult"/>containing <see cref="BaseDTO"/>s requested.</returns>
    protected ActionResult<IQueryable<TDTO>> GetEntities<TDTO, TEntity>()
        where TDTO : class
        where TEntity : class
    {
        try
        {
            var entitySet = _mapper.ProjectTo<TDTO>(_context.Set<TEntity>()).AsNoTracking();
            return Ok(entitySet);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error encountered on getting records for entities of type {type} from database. {exception}", typeof(TEntity).Name, ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Gets a <see cref="BaseDTO"/> by Id.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="BaseEntity"/></typeparam>
    /// <typeparam name="TDTO"><see cref="BaseDTO"/></typeparam>
    /// <param name="id">The unique id.</param>
    /// <returns><see cref="ActionResult"/>containing <see cref="BaseDTO"/> requested.</returns>
    protected async Task<IActionResult> GetOneAsync<TEntity, TDTO>(string id)
        where TEntity : BaseEntity
        where TDTO : BaseDTO
    {
        try
        {
            TEntity? entity = (TEntity?)(await _context.FindAsync(typeof(TEntity), id));

            if (entity is null)
            {
                return NotFound();
            }
    
            var dto = _mapper.Map<TDTO>(entity);
            return Ok(dto);
        }
        catch (ArgumentNullException)
        {
            return BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error encountered on getting records for entities of type {type} from database. {exception}", typeof(TEntity).Name, ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
