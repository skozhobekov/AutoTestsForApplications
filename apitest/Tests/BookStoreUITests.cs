using apitest.BookStoreDto;
using apitest.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace apitest;

public class BookStoreUITests
{
    private IBookStore API;

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();

        services
            .AddRefitClient<IBookStore>()
            .ConfigureHttpClient(c => { c.BaseAddress = new Uri("https://demoqa.com"); });

        var provider = services.BuildServiceProvider();
        API = provider.GetRequiredService<IBookStore>();
    }
    
    [Test]
    public async Task GetToken()
    {
        var user = new UserDTO { UserName = "Sanjar123", Password = "StrongPass123!" };
        var response = await API.GenerateTokenAsync(user);
        response.Token.Should().NotBeNullOrEmpty();
        response.Status.Should().Be("Success");
        response.Result.Should().Contain("authorized");
    }
    
    [Test]
    public async Task AddBookAndCheckUI()
    {
        string isbn = "9781449325862";
    }
}