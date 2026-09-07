using apitest.Dapper.DapperDto;

namespace apitest.Dapper.DapperInterfaces;

public interface IAddressRepository
{
    Task<IEnumerable<AddressDTO>> GetAllAddressesAsync();
    Task<AddressDTO> GetAddressByUserId(int userId);
}