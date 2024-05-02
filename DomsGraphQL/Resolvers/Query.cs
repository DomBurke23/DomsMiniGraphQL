namespace DomsGraphQL.Resolvers;

public class Query
{
    public Task<HealthCheckResponse> GetHealthCheck([Service] IHealthCheckService healthCheckService)
    {
        return healthCheckService.HealthCheck();
    }
}
