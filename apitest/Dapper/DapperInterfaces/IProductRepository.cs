using apitest.Dapper.DapperDto;

namespace apitest.Dapper.DapperInterfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(int id);
}