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
<<<<<<< HEAD
        services.AddDataAccess(conn);
=======
        //services.AddDataAccess(conn);
>>>>>>> homework-13-pr
        Provider = services.BuildServiceProvider();
    }
}