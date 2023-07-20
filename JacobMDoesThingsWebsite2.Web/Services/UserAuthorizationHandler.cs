namespace JacobMDoesThingsWebsite2.Web.Services;

public class UserAuthorizationHandler : DelegatingHandler
{
    private readonly ITokenAcquisition _tokenAcquisition;
    private readonly string[] _scopes;

    public UserAuthorizationHandler(ITokenAcquisition tokenAcquisition, B2CClient client)
    {
        _tokenAcquisition = tokenAcquisition;
        _scopes = client.UserScopes ?? throw new NullReferenceException(nameof(client.UserScopes));
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Acquire the access token.
        string authorizationHeader = await _tokenAcquisition.GetAccessTokenForUserAsync(_scopes, authenticationScheme: OpenIdConnectDefaults.AuthenticationScheme);
       
        // Use the access token to call a protected web API.
        request.Headers.Add("Authorization", "Bearer " + authorizationHeader);

        return await base.SendAsync(request, cancellationToken);
    }
}