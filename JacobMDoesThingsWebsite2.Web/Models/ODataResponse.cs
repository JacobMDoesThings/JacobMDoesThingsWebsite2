namespace JacobMDoesThingsWebsite2.Web.Models;

public class ODataResponse<T>
    where T : class
{
    [JsonPropertyName("@odata.count")]
    public int Count { get; set; }

    [JsonPropertyName("@odata.context")]
    public string Context { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public IEnumerable<T>? Data { get; set; }
}
