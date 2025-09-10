using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data.Common;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly DbConnection _connection;
    private readonly IConfiguration _configuration;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string? connectionString = _configuration.GetConnectionString("PostgresConnection");
        _connection = new NpgsqlConnection(connectionString);
    }

    public DbConnection DbConnection => _connection;
}

