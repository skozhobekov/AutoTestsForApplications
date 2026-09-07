using Microsoft.Extensions.DependencyInjection;

namespace apitest;

public class TestPrecondition
{
    public ServiceProvider Provider { get; }

    public TestPrecondition(ServiceProvider provider)
    {
        Provider = provider;
    }

    public TestPrecondition()
    {
        var services = new ServiceCollection();

        var dbPath = Path.Combine(
            AppContext.BaseDirectory,
            "marketplace.db"
        );

        var connectionString = $"Data Source={dbPath}";

        services.AddDataAccess(connectionString);

        Provider = services.BuildServiceProvider();
    }
}