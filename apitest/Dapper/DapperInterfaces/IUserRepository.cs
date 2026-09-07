using apitest.BookStoreDto;
using UserDTO = apitest.Dapper.DapperDto.UserDTO;

namespace apitest.Dapper.DapperInterfaces;

public interface IUserRepository
{
    Task<IEnumerable<UserDTO>> GetAllAsync();
    Task<DapperDto.UserDTO> GetByIdAsync(int id);
    Task<DapperDto.UserDTO> GetUserByFirstAndLastName(string firstName, string lastName);
}