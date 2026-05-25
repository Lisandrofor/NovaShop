using Microsoft.Data.Sqlite;
using System.Data;

namespace NovaShop.Data
{
    public class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection(IConfiguration config)
        {
            _connectionString =
                config.GetConnectionString("DefaultConnection")
                 ?? throw new Exception(
                    "No se encontró la cadena de conexión."
                );
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
