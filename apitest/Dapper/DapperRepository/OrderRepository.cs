using apitest.Dapper.DapperDto;
using apitest.Dapper.DapperInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;

namespace apitest.Dapper.DapperRepository;

public class OrderRepository : IOrderRepository
{
    private readonly string connectionString;
    
    public OrderRepository(string connection)
    {
        connectionString = connection;
    }
    
    public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
    {
        using var db = new SqliteConnection(connectionString);
        var orders = await db.QueryAsync<OrderDTO>("SELECT * FROM Orders");
        return orders;
    }
    
    public async Task<OrderDTO> GetOrderByIdAsync(int id)
    {
        using var db = new SqliteConnection(connectionString);
        var order = await db.QueryFirstOrDefaultAsync<OrderDTO>("SELECT * FROM Orders where Id = @id", new { id });
        return order;
    }

    public async Task<IEnumerable<string>> GetCitiesWhereAccessoriesBoughtAsync()
    {
        using var db = new SqliteConnection(connectionString);

        var cities = await db.QueryAsync<string>(@"
            SELECT DISTINCT a.City
            FROM Addresses a
            JOIN Orders o ON o.UserId = a.UserId
            JOIN OrderItems oi ON oi.OrderId = o.Id
            JOIN Products p ON p.Id = oi.ProductId
            JOIN Categories c ON c.Id = p.CategoryId
            WHERE c.Name = 'Аксессуары'
        ");

        return cities;
    }

    public async Task<IEnumerable<int>> GetUsersWhoBoughtTvAndAccessoriesAsync()
    {
        using var db = new SqliteConnection(connectionString);

        var users = await db.QueryAsync<int>(@"
        SELECT DISTINCT o.UserId
        FROM Orders o
        JOIN OrderItems oi ON o.Id = oi.OrderId
        JOIN Products p ON oi.ProductId = p.Id
        WHERE p.CategoryId = 4
          AND o.UserId IN
          (
              SELECT DISTINCT o2.UserId
              FROM Orders o2
              JOIN OrderItems oi2 ON o2.Id = oi2.OrderId
              JOIN Products p2 ON oi2.ProductId = p2.Id
              WHERE p2.CategoryId = 6
          )
    ");

        return users;
    }
    
    
}