using FluentAssertions;
using System.Text.Json;
using apitest.DTO;

namespace apitest;

public class UserDataTests
{
    private List<UserData>? users;

    [OneTimeSetUp]
    public void Setup()
    {
        string json = File.ReadAllText("DTO/UsersData.json");

        users = JsonSerializer.Deserialize<List<UserData>>(json);
    }



    [Test]
    public async Task UsersCount_ShouldBe10()
    {
        users.Count.Should().Be(10);
    }

    [Test]
    public void Test2()
    {
        users![0].Name.Should().Be("Alice Johnson");
    }

    public void FirstUser_ShouldBeAliceJohnson()
    {
        users!.First().Name.Should().Be("Alice Johnson");
    }
}