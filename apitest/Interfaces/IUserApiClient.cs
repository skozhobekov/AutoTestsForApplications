using apitest.DTO;
using Refit;

namespace apitest.Interfaces;

public interface IUserApiClient
{
    [Get("/users/{id}")]
    Task<UserResponceDTO> GetUserAsync(int id);

    [Post("/users")]
    Task<CreateUserRequestDto> PostUserAsync([Body] CreateUserRequestDto userRequestDto);

    [Put("/users/{id}")]
    Task <CreateUserRequestDto> PutUserAsync(int id, [Body] CreateUserRequestDto userRequestDto);
    
    [Delete("/users/{id}")]
    Task <ApiResponse<string>> DeleteUserAsync(int id);
}
//x-api-key: free_user_3HMdkNLTV9xQwVXyEyCt3544HcE