using apitest.Dapper.DapperDto;

namespace apitest.Dapper.DapperInterfaces;

public interface ICategoryRepository

    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
    }
