using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class DapperContext
{
    private IConfiguration _configuration;
    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnString"));
    }
}
