using apitest.Dapper.DapperDto;
using apitest.Dapper.DapperInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;

namespace apitest.Dapper.DapperRepository;

public class CategoryRepository : ICategoryRepository
{
    private readonly string connectionString;
    
    public CategoryRepository(string connection)
    {
        connectionString = connection;
    }
    
    public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
    {
        using var db = new SqliteConnection(connectionString);
        var categories = await db.QueryAsync<CategoryDTO>("SELECT * FROM Categories");
        return categories;
    }
}