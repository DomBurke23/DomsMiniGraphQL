namespace DomsGraphQL.HealthCheck;

public class HealthCheckService : IHealthCheckService
{
    public async Task<HealthCheckResponse> HealthCheck()
    {
        return new HealthCheckResponse() { Success = true };
    }
}
