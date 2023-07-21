namespace JacobMDoesThingsWebsite2.Web.Services;

public class ServiceAuthorizationHandler : DelegatingHandler
{
    private readonly ServiceTokenAcquirer _tokenAcquirer;

    public ServiceAuthorizationHandler(ServiceTokenAcquirer tokenAcquirer)
    {
        _tokenAcquirer = tokenAcquirer;    
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        string token = await _tokenAcquirer.AcquireTokenAsync(cancellationToken);
        request.Headers.Add("Authorization", "Bearer " + token);
        return await base.SendAsync(request, cancellationToken);
    }
}