namespace JacobMDoesThingsWebsite2.Web.Extensions;

/// <summary>
/// Extension methods for the services.
/// </summary>
internal static class ServiceExtensions
{
    /// <summary>
    /// Creates a <see cref="ODataResponse{T}"/> from the provided <seealso cref="HttpResponseMessage"/>
    /// </summary>
    /// <typeparam name="T">The object type for <see cref="ODataResponse{T}.Data"/></typeparam>
    /// <param name="response">The <see cref="HttpResponseMessage"/> to parse.</param>
    /// <returns><see cref="ODataResponse{T}"/> for the specified type.</returns>
    internal async static Task<ODataResponse<T>?> ParseOdataResponse<T>(this HttpResponseMessage response)
        where T : class
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        ODataResponse<T>? obj;
        obj = JsonSerializer.Deserialize<ODataResponse<T>>(responseContent);

        return obj;
    }

    /// <summary>
    /// Creates <see cref="HttpContent"/> for a given object.
    /// </summary>
    /// <param name="obj">The <see cref="object"/> to serialize.</param>
    /// <returns><see cref="HttpContent"/> representing the object provided.</returns>
    internal static HttpContent CreateHTTPContent(this object obj)
    {
        var serialized = JsonSerializer.Serialize(obj);
        var content = new StringContent(serialized, Encoding.UTF8, "application/json");
        return content;
    }
}
