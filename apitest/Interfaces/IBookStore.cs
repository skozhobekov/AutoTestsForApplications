using apitest.BookStoreDto;
using apitest.DTO;
using Refit;

namespace apitest.Interfaces;


public interface IBookStore
{
    [Post("/Account/v1/User")]
    Task<CreateUserResponseDto> CreateUserAsync([Body] UserDTO user);  
    
    [Post("/Account/v1/GenerateToken")]
    Task<GetTokenDto> GenerateTokenAsync ([Body] UserDTO user); 
    
}