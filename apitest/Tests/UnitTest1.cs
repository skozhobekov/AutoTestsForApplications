using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using apitest.DTO;
namespace apitest;
public class Tests
{
    private static HttpClient client;
    //работает только для тестов в классе Test
    [OneTimeSetUp]
    public void Setup()
    {
        client = new HttpClient()
        {
            BaseAddress = new Uri("https://reqres.in/api/")
        };
        client.DefaultRequestHeaders.Add("x-api-key", "free_user_3HMdkNLTV9xQwVXyEyCt3544HcE");
    }

    [Test]
    public async Task Test1()
    { 
        //Get запрос
        using HttpResponseMessage response = await client.GetAsync("users/2");
        //проверка статускода
        response.EnsureSuccessStatusCode();
        
    }

    [Test]
    public async Task Test2()
    {
        using HttpResponseMessage response = await client.GetAsync("users/2");
        string jsonGet = await response.Content.ReadAsStringAsync();
        UserResponceDTO userResponce = JsonSerializer.Deserialize<UserResponceDTO>(jsonGet);
        UsersDataDTO users = userResponce.Data;
        Assert.That(users.Id, Is.EqualTo(2));
        
    }

    [Test]
    public async Task Test3()
    {
        CreateUserRequestDto createUserRequestDto = new CreateUserRequestDto
        {
            Name = "Sanzhar",
            Job = "Slotegrator"
        };
        using HttpResponseMessage response =
            await client.PostAsJsonAsync("users", createUserRequestDto);
        response.EnsureSuccessStatusCode();

        string jsonGet = await response.Content.ReadAsStringAsync();
        CreateUserResponseDto1 createUserResponseDto1 = JsonSerializer.Deserialize<CreateUserResponseDto1>(jsonGet);
        
        Assert.That(createUserResponseDto1.Name, Is.EqualTo("Sanzhar"));
        Assert.That(createUserResponseDto1.Job, Is.EqualTo("Slotegrator"));
        Assert.That(createUserResponseDto1.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(createUserResponseDto1.CreatedAt, Is.Not.EqualTo(default(DateTime)));
    }


    [Test]
    public async Task Test4()
    {
        CreateUserRequestDto createUserRequestDto = new CreateUserRequestDto { Name = "Sanzhar", Job = "Google"};
        using HttpResponseMessage response =
            await client.PutAsJsonAsync("users/2", createUserRequestDto);
        response.EnsureSuccessStatusCode();
    }
    
    [Test]
    public async Task Test5()
    {
        using HttpResponseMessage response = await client.DeleteAsync("users/2");
        response.EnsureSuccessStatusCode();
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        client.Dispose();
    }
}
