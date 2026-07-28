using NovaShop.Data;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;
using System;
using Dapper;

namespace NovaShop.Repositories
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly DbConnection _connection;

        public CarritoRepository(
             DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Carrito>> ObtenerCarritos()

        {

            using var connection = _connection.CreateConnection();

            string sql = """
                        SELECT *
                        FROM Carrito
                        """;

            return await connection
                .QueryAsync<Carrito>(sql);

        }

        public async Task GuardarCarrito(Carrito carrito)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                INSERT INTO Carrito
                (
                    IdCarrito,
                    IdUsuario,
                    Items
                    
                )
                VALUES
                (
                    @IdCarrito,
                    @IdUsuario,
                    @Items
                    
                    
                )
            """;

            await connection.ExecuteAsync(sql, carrito);
        }
        public async Task AgregarItemCarrito(ItemCarrito item)
        {
            using var connection = _connection.CreateConnection();

            var sql = @"
        INSERT INTO ItemCarrito
        (IdCarrito, IdProducto, Cantidad)
        VALUES
        (@IdCarrito, @IdProducto, @Cantidad);";

            await connection.ExecuteAsync(sql, item);
        }





        public async Task<Carrito?> ObtenerPorId(long id)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT *
                FROM Carrito
                WHERE Id = @Id
            """;

            return await connection
                .QueryFirstOrDefaultAsync<Carrito>(
                    sql,
                    new { Id = id }
                );

        }

        public async Task<bool> ExisteCarrito(long id)
        {
            using var connection = _connection.CreateConnection();
            string sql = """
                SELECT COUNT(1)
                FROM Carrito
                WHERE Id = @Id
            """;
            int count = await connection.ExecuteScalarAsync<int>(sql, new { Id = id });
            return count > 0;
        }

        public async Task ActualizarItemCarrito(long idItemCarrito, UpdateItemRequest request)
        {
            using var connection = _connection.CreateConnection();

            var sql = """
                UPDATE ItemCarrito
                SET IdProducto = @IdProducto,
                Cantidad = @Cantidad
        WHERE IdItemCarrito = @IdItemCarrito
        """;

            await connection.ExecuteAsync(sql, new
            {
                IdItemCarrito = idItemCarrito,
                request.IdProducto,
                request.Cantidad
            });
        }

        public async Task EliminarItemCarrito(long id)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT *
                DELETE ItemCarrito
                WHERE Id = @IdItemCarrito
            """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
