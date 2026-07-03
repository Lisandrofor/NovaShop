using NovaShop.Data;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;
using System;
using Dapper;

namespace NovaShop.Repositories
{
    public class ProductoRepository : IProductosRepository
    {
        private readonly DbConnection _connection;

        public ProductoRepository(
             DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()

        {

            using var connection = _connection.CreateConnection();

            string sql = """
                        SELECT *
                        FROM Productos
                        """;

            return await connection
                .QueryAsync<Producto>(sql);

        }

        public async Task GuardarProducto(Producto producto)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                INSERT INTO Productos
                (
                    Id,
                    Descripcion,
                    CreatedAt,
                    Stock,
                    Precio,
                    Categoria
                )
                VALUES
                (
                    @Id,
                    @Descripcion,
                    @CreateAT,
                    @Stock,
                    @Precio,
                    @Categoria,
                    @CreatedAt
                    
                )
            """;

            await connection.ExecuteAsync(sql, producto);
        }

        public async Task<Producto?> ObtenerProductoId(Guid id)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT *
                FROM Productos
                WHERE Id = @Id
            """;

            return await connection
                .QueryFirstOrDefaultAsync<Producto>(
                    sql,
                    new { Id = id }
                );

        }

        public async Task<bool> ActualizarProducto(Producto producto)
        {
            using var connection = _connection.CreateConnection();

            string sql = """
        UPDATE Productos
        SET
            Descripcion = @descripcion,
            precio = @precio,
            Stock = @Stock
        WHERE Id = @Id
    """;

            int filasAfectadas = await connection.ExecuteAsync(sql, producto);

            return filasAfectadas > 0;
        }

        public async Task EliminarProducto(Guid id)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT *
                DELETE Productos
                WHERE Id = @Id
            """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }



    }
  }
