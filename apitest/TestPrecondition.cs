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

        var dpPath = Path.Combine((ToString()));
        var ConnString = $"Data Source={dpPath}";
        services.AddDataAccess(ConnString);
        Provider = services.BuildServiceProvider();
    }
    
}