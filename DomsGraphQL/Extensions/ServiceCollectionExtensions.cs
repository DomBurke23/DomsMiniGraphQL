namespace DomsGraphQL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IHealthCheckService, HealthCheckService>();
        services.AddScoped<ICustomerService, CustomerService>();
    }
}
