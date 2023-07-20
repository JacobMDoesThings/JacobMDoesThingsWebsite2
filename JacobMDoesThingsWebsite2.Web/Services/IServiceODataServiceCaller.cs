namespace JacobMDoesThingsWebsite2.Web.Services;

public interface IServiceODataServiceCaller
{
    /// <summary>
    /// Gets <see cref="ODataResponse{T}"/> of type <seealso cref="SessionInformationDTO"/>
    /// modified by optional Odata query string.
    /// </summary>
    /// <param name="query">The odata query.</param>
    /// <returns>An <see cref="ODataResponse{T}"/>of type <see cref="SessionInformationDTO"/></returns>
    public Task<ODataResponse<SessionInformationDTO>> GetSessionInformationAsync(string query = "");

    /// <summary>
    /// Posts <see cref="SessionInformationDTO"/> to Odata endpoint.
    /// </summary>
    /// <param name="value">The <see cref="SessionInformationDTO"/> to be posted.</param>
    /// <returns>A <see cref="SessionInformationDTO"/> representing the value created.</returns>
    public Task<SessionInformationDTO?> PostSessionInformationAsync(SessionInformationDTO value);
}
