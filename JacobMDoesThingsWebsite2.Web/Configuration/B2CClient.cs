namespace JacobMDoesThingsWebsite2.Web.Configuration;

public class B2CClient
{

    public string? ClientId { get; set; }

    public string? ClientSecret { get; set; }

    public string? Instance { get; set; }

    public string? Domain { get; set; }

    public string? SignUpSignInPolicyId { get; set; }

    public string? CallbackPath { get; set; }

    public string? ClientScopes { get; set; }

    public string[]? UserScopes { get; set; }
}