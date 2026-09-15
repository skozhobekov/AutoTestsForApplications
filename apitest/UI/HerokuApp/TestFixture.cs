using Microsoft.Extensions.DependencyInjection;

namespace apitest.UI;

public class TestFixture
{
    public ServiceProvider Provider { get; }

    public TestFixture()
    {
        var services = new ServiceCollection();

        var dbPath = Path.Combine(AppContext.BaseDirectory, "marketplace.db");
        var conn = $"Data Source={dbPath}";
        services.AddDataAccess(conn);
        Provider = services.BuildServiceProvider();
    }
}