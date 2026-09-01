using apitest.Helper;
using apitest.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace apitest;

public class PetTests
{
    
    private IPetAPI PetApi { get; set; }


    [OneTimeSetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
        };
        services.AddRefitClient<IPetAPI>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://petstoreapi.com/v1");
            })
            
            .ConfigurePrimaryHttpMessageHandler(() => handler);
        var Provider = services.BuildServiceProvider();
        PetApi = Provider.GetRequiredService<IPetAPI>();

    }
    
    [Test]
    public async Task GetAllPetsAsync()
    {
        var pets = await PetApi.GetAllPetsAsync();
        pets.Should().NotBeNull();
    }
    
    [Test]
    public async Task GetPetByIdAsync()
    {
        var petsAsync = await PetApi.GetAllPetsAsync();
        petsAsync.Data.Should().HaveCount(20);

        var rndId = RandomHelper.GetRandomItem(petsAsync.Data);
        var pet = await PetApi.GetPetByIdAsync(rndId.id);
        var pet2 = petsAsync.Data.Where(x => x.id == pet.id).First();
        pet2.Should().NotBeNull();
        
    }
    
    [Test]
    public async Task GetPetByStatusAndLimitAsync()
    {
        var petsAsync = await PetApi.GetAllPetsByStatusAndLimitAsync("ADOPTED", 12);
        petsAsync.Data.Should().HaveCount(12);

    }
}