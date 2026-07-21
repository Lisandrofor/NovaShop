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
                        FROM Carritos
                        """;

            return await connection
                .QueryAsync<Carrito>(sql);

        }

        public async Task GuardarCarrito(Carrito carrito)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                INSERT INTO Carritos
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
    }
}
