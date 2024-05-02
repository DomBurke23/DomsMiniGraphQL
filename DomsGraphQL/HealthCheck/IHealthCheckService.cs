namespace DomsGraphQL.HealthCheck;

public interface IHealthCheckService
{
    Task<HealthCheckResponse> HealthCheck();
}
