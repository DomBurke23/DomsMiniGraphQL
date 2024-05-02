namespace DomsGraphQL.Authentication;

public class AuthenticationRequestInterceptor : DefaultHttpRequestInterceptor
{
    public override ValueTask OnCreateAsync(
        HttpContext context,
        IRequestExecutor requestExecutor,
        IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var claims = context
            .User
            .Claims
            .ToDictionary(x => x.Type, x => x.Value);
        }
        return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
    }
}