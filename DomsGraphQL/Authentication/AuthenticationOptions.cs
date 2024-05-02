namespace DomsGraphQL.Authentication;

public class AuthenticationOptions
{
    public string Audience { get; set; }

    public string Authority { get; set; }

    public string BaseUrl { get; set; }

    public string ApiKey { get; set; }

    public bool ValidateSessions { get; set; }

    public string IssuerLogin { get; set; }

    public string IssuerRegister { get; set; }

    public bool ValidateLifetime { get; set; } = true;
}