namespace apitest;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Dapper;

public class DapperTest
{

    [Test]
    public async Task Initialize()
    {
        var connectionString = "Data Source=marketplace.db";
        await using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();
        
    }
    
}