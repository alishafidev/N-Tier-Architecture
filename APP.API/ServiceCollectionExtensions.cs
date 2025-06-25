using Microsoft.EntityFrameworkCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {

        #region DB Connection

        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly("APP.DAL");
                    npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
        });

        #endregion

        // Register repositories and services
        services.AddScoped<IBookRepo, BookRepo>();
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}