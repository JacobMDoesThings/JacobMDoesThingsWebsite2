namespace JacobMDoesThingsWebsite2.Web.Services;

/// <summary>
/// Handles Odata service calls.
/// </summary>
public class ServiceOdataServiceCaller : IServiceODataServiceCaller
{
    public readonly HttpClient _httpClient = new();
    public readonly OdataServiceCallerOptions _options;

    /// <summary>
    /// Initializes the SessionFunctionsCaller.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> responsible for the odata calls.</param>
    /// <param name="options">The <see cref="OdataServiceCallerOptions"/> options.</param>
    public ServiceOdataServiceCaller(HttpClient httpClient, OdataServiceCallerOptions options)
    {
        _httpClient = httpClient;
        _options = options;
        _httpClient.BaseAddress = options.BaseURI;
    }

    ///<inheritdoc/>
    public async Task<ODataResponse<SessionInformationDTO>> GetSessionInformationAsync(string query = "")
    {
        var result = await _httpClient.GetAsync($"{_options.SessionInformation}{query}");
        ODataResponse<SessionInformationDTO>? returnVal;

        if (!result.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Unsuccessful status code returned {result.StatusCode} : {result.ReasonPhrase}");
        }
        else
        {
            returnVal = await result.ParseOdataResponse<SessionInformationDTO>();
        }

        return returnVal ?? new ODataResponse<SessionInformationDTO>();
    }

    ///<inheritdoc/>
    public async Task<SessionInformationDTO?> PostSessionInformationAsync(SessionInformationDTO value)
    {
        var content = value.CreateHTTPContent();
        var result = (await _httpClient.PostAsync(_options.SessionInformation, content));
        if (!result.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Unsuccessful status code returned {result.StatusCode} : {result.ReasonPhrase}");
        }

        return await result.Content.ReadFromJsonAsync<SessionInformationDTO>();
    }
}