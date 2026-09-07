using apitest.Dapper.DapperDto;

namespace apitest.Dapper.DapperInterfaces;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
    Task<OrderDTO> GetOrderByIdAsync(int id);
    
    Task<IEnumerable<string>> GetCitiesWhereAccessoriesBoughtAsync();

    Task<IEnumerable<int>> GetUsersWhoBoughtTvAndAccessoriesAsync();
}