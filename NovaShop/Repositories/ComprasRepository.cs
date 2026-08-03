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

        public async Task EliminarOrden(long id)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT *
                DELETE OrdenCompras
                WHERE Id = @IdOrdenCompras
            """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<OrdenCompras?> ObtenerPorId(long id)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT *
                FROM OrdenCompras
                WHERE Id = @Id
            """;

            return await connection
                .QueryFirstOrDefaultAsync<OrdenCompras>(
                    sql,
                    new { Id = id }
                );

        }

        public async Task AgregarOrdenes(OrdenCompras  orden)
        {
            using var connection = _connection.CreateConnection();

            var sql = @"
        INSERT INTO OrdenCompras
        (IdOrdenCompra, IdUsuario,FechaCompra)
        VALUES
        (@IdOrdenCompra, @IdUsuario, @FechaCompra);";

            await connection.ExecuteAsync(sql, orden);
        }
    }
}
