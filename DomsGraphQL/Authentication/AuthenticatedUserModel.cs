namespace DomsGraphQL.Authentication;

public class AuthenticatedUserModel
{
    public string Bearer { get; set; }
    private IDictionary<string, string> Claims { get; }

    public AuthenticatedUserModel(string bearer,
        IDictionary<string, string> claims)
    {
        Bearer = bearer;
        Claims = claims;
    }
}

public class AuthenticatedUserGlobalState : GlobalStateAttribute
{

}