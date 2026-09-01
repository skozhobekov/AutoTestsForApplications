using Microsoft.Extensions.DependencyInjection;

namespace apitest;

public static class DataAccessModule
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IUserRepository>();
        return null;
    }
}

public interface IUserRepository
{
}
