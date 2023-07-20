namespace JacobMDoesThingsWebsite2.Web.Controllers;

/// <summary>
/// The <see cref="ODataController"/> responsible for managing 
/// <seealso cref="SessionInformationEntity"/> and <seealso cref="SessionInformationDTO"/>
/// </summary>
public class SessionInformationController : BaseController
{
    ///<inheritdoc/>
    public SessionInformationController(ILoggerFactory loggerFactory, JacobMDoesThingsWebsite2Context context, IMapper mapper) 
        : base(loggerFactory, context, mapper)
    {     
    }

    /// <summary>
    /// The query enabled endpoint for getting <see cref="SessionInformationDTO"/s> converted from
    /// <seealso cref="SessionInformationEntity"/>.
    /// </summary>
    /// <returns>an <see cref="IActionResult"/> containing <seealso cref="SessionInformationDTO"/> information.</returns>
    [EnableQuery]
    [RequiredScope("SessionInformation.Writer")]
    [Authorize(AuthenticationSchemes = "AzureAdB2CApi")]
    public ActionResult<IQueryable<SessionInformationDTO>> Get()
    {
        return GetEntities<SessionInformationDTO, SessionInformationEntity>();
    }

    /// <summary>
    /// The endpoint for getting <see cref="SessionInformationDTO"/> by Id, converted from
    /// <seealso cref="SessionInformationEntity"/>.
    /// </summary>
    /// <returns>an <see cref="IActionResult"/> containing <seealso cref="SessionInformationDTO"/> information.</returns>
    [EnableQuery]
    public async Task<IActionResult> Get([FromRoute] string key)
    {
        return await GetOneAsync<SessionInformationEntity, SessionInformationDTO>(key);
    }

    /// <summary>
    /// The endpoint for posting new <see cref="SessionInformationEntity"/> from a <seealso cref="SessionInformationDTO"/>
    /// </summary>
    /// <param name="sessionInformation">The <see cref="SessionInformationDTO"/> to be posted.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the created <see cref="SessionInformationDTO"/> 
    /// converted from <see cref="SessionInformationEntity"/>.
    /// </returns>
    [RequiredScope("SessionInformation.Writer")]
    [Authorize(AuthenticationSchemes = B2CApiScheme)]
    public async Task<IActionResult> Post([FromBody] SessionInformationDTO sessionInformation)
    {
        return await PostOneAsync<SessionInformationDTO, SessionInformationEntity>(sessionInformation);
    }

}

