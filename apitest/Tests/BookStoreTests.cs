using apitest.BookStoreDto;
using apitest.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using apitest.Interfaces;
using apitest.BookStoreDto;
using FluentAssertions;

namespace apitest;

public class BookStoreTests
{
    private IBookStore API;

    [OneTimeSetUp]
    public void Setup()
    {
        var services = new ServiceCollection();

        services
            .AddRefitClient<IBookStore>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://demoqa.com");
            });

        var provider = services.BuildServiceProvider();
        API = provider.GetRequiredService<IBookStore>();
    }

    //cb664c9d-e559-46bb-8fec-5a27ded41e9e
// eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6IlNhbmphcjEyMyIsInBhc3N3b3JkIjoiU3Ryb25nUGFzczEyMyEiLCJpYXQiOjE3ODgyMDExOTd9.As8WDCzL0izA1R73RsFmkOvam3qC79p_14KMfUf6fwk
    [Test]
    public async Task CreateUser()
    {
        var user = new UserDTO { UserName = "Sanjar123", Password = "StrongPass123!" };
        var response = await API.CreateUserAsync(user);
        
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
}