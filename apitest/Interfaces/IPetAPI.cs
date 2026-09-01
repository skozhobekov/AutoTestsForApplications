using apitest.DTO;
using Refit;

namespace apitest.Interfaces;

public interface IPetAPI
{
     [Get("/pets")]
     Task <AllPetsResponseDto> GetAllPetsAsync();
     
     [Get("/pets/{Id}")]
     Task<PetDto> GetPetByIdAsync(string id);
     
     [Get("/pets")]
     Task <AllPetsResponseDto> GetAllPetsByStatusAndLimitAsync([Query] string status, [Query] int limit);
     
}