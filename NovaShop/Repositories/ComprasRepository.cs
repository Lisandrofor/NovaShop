using NovaShop.Data;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;
using System;
using Dapper;
namespace NovaShop.Repositories
{
    public class ComprasRepository: ICompraRepository
    {

        private readonly DbConnection _connection;
        public ComprasRepository(DbConnection connection) {
        
        _connection = connection;
        }

        public async Task<IEnumerable<OrdenCompras>> ObtenerOrdenesComp()

        {

            using var connection = _connection.CreateConnection();

            string sql = """
                        SELECT *
                        FROM OrdenCompras
                        """;

            return await connection
                .QueryAsync<OrdenCompras>(sql);

        }
    }
}
