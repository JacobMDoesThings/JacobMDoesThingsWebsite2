namespace JacobMDoesThingsWebsite2.Web.Services;

public class ServiceTokenAcquirer
{
    private readonly B2CClient _b2cClient;
    private readonly string _grantType;
    private readonly HttpClient _httpClient;
    private readonly Dictionary<string, string> _headerValues;
    private readonly string _uri;
    private readonly ILogger _logger;
    private KeyValuePair<string, string> _tokenAndExpireValue = new();

    public ServiceTokenAcquirer(HttpClient client, B2CClient b2cClient,
        ILogger<ServiceAuthorizationHandler> logger, string grantType = "client_credentials")
    {
        if (b2cClient.ClientId is null ||
            b2cClient.ClientSecret is null ||
            b2cClient.ClientScopes is null)
        {
            throw new ArgumentException(nameof(B2CClient));
        }

        _logger = logger;
        _b2cClient = b2cClient;
        _grantType = grantType;
        _httpClient = client;

        _headerValues = new Dictionary<string, string> {
            { "client_id", _b2cClient.ClientId },
            { "client_secret", _b2cClient.ClientSecret },
            { "scope", _b2cClient.ClientScopes },
            { "grant_type", _grantType },
        };

        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _uri = $"{b2cClient.Instance}/{b2cClient.Domain}/{b2cClient.SignUpSignInPolicyId}/oauth2/v2.0/token";
    }

    public async Task<string> AcquireTokenAsync(CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(_tokenAndExpireValue.Key) ||
            HasExpired(_tokenAndExpireValue.Value))
        {
            var result = await _httpClient.PostAsync(_uri, new FormUrlEncodedContent(_headerValues), cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync(cancellationToken);
                SetTokenInformation(content, ref _tokenAndExpireValue);
            }
            else
            {
                _logger.LogError("Problem retrieving access token {StatusCode} {ReasonPhrase}"
                    , result.StatusCode.ToString(), result.ReasonPhrase);
            }
        }

        return _tokenAndExpireValue.Key;
    }

    private static string? DeserializeToken(string jsonString, string tokenName)
    {
        var value = JsonSerializer.Deserialize<JsonNode>(jsonString);

        if (value is not null)
        {
            var tokenValue = value[tokenName];
            var returnVal = tokenValue?.GetValue<dynamic>();

            return Convert.ToString(returnVal);
        }

        return string.Empty;
    }

    private static bool HasExpired(string expiresOnTokenValue)
    {
        if (string.IsNullOrEmpty(expiresOnTokenValue))
        {
            return true;
        }

        var tokenValidTime = DateTimeOffset.FromUnixTimeSeconds(int.Parse(expiresOnTokenValue)).UtcDateTime;
        var now = DateTimeOffset.UtcNow;
        var timeLeft = tokenValidTime - now;

        return timeLeft < TimeSpan.FromMinutes(10);
    }

    private static void SetTokenInformation(string content, ref KeyValuePair<string, string> tokenKeyExpirationValueRef)
    {
        string? token = DeserializeToken(content, "access_token");
        string? expiration = DeserializeToken(content, "expires_on");

        tokenKeyExpirationValueRef = new KeyValuePair<string, string>(token ?? string.Empty, expiration ?? string.Empty);
    }
}
