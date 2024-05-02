namespace DomsGraphQL;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        IdentityModelEventSource.ShowPII = true;

        var cultureInfo = new CultureInfo("en-GB");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        services.AddErrorFilter<CustomExceptionHandler>();

        var allowedOrigins = new List<string>();
        Configuration.GetSection("CORS:AllowedOrigins").Bind(allowedOrigins);

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins(allowedOrigins.ToArray())
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        services.AddApplicationInsightsTelemetry();
        services.AddMemoryCache();

        services.AddGraphQLServer()
            .AddHttpRequestInterceptor<AuthenticationRequestInterceptor>()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddAuthorization();

        services.AddServices();
        services.AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; });
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.UseAuthentication();
        app.UseCors();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
            endpoints.MapControllers();
        });
    }
}
