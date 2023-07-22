namespace JacobMDoesThingsWebsite2.Web.Services;

/// <summary>
/// Used for service to attach a token acquired by <see cref="ServiceTokenAcquirer"/> to 
/// <see cref="HttpRequestMessage"/> for authorizing calls. Required for B2C client credential
/// flow.
/// </summary>
public class ServiceAuthorizationHandler : DelegatingHandler
{
    private readonly ServiceTokenAcquirer _tokenAcquirer;

    public ServiceAuthorizationHandler(ServiceTokenAcquirer tokenAcquirer)
    {
        _tokenAcquirer = tokenAcquirer;    
    }

    ///<inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        string token = await _tokenAcquirer.AcquireTokenAsync(cancellationToken);
        request.Headers.Add("Authorization", "Bearer " + token);
        return await base.SendAsync(request, cancellationToken);
    }
}