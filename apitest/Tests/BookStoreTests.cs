using apitest.BookStoreDto;
using apitest.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using apitest.Interfaces;
using apitest.BookStoreDto;
using apitest.DTO;
using FluentAssertions;

namespace apitest;


[TestFixture]
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
    
    [Test]
    public async Task CreateUser()
    {
        var user = new UserDTO { UserName = "Sanjar1234", Password = "StrongPass123!" };
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

    
    
    [Test]
    public async Task GetUserId()
    {
        var user = new UserDTO { UserName = "Sanjar1223457", Password = "StrongPass123!" };
        var response = await API.CreateUserAsync(user);
        var id = response.UserID;
        Console.WriteLine(id);
        id.Should().NotBeNullOrEmpty();
    }

    [Test]
    public async Task AddBookAsync()
    {
        var user = new UserDTO { UserName = "Sanjar1234223111", Password = "StrongPass123!" };
        var response = await API.ReturnUserIdAsync(user);
        Console.WriteLine(response);
    }
    

    
}