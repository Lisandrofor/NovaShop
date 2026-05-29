
using Microsoft.AspNetCore.Connections;
using NovaShop.Data;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;
using System;
using Dapper;

namespace NovaShop.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbConnection _connection;

        public UsuarioRepository(
             DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> ExisteDNI(long dni)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT COUNT(*)
                FROM Usuarios
                WHERE Dni = @dni
            """;

            int cantidad =
                await connection.ExecuteScalarAsync<int>(sql,
                    new { Dni = dni }
                );

            return cantidad > 0;
        }

        public async Task<bool> ExisteEmail(string email)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT COUNT(*)
                FROM Usuarios
                WHERE Email = @Email
            """;

            int cantidad =
                await connection.ExecuteScalarAsync<int>(sql,
                    new { Email = email }
                );

            return cantidad > 0;
        }


        public async Task Guardar(Usuario usuario)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                INSERT INTO Usuarios
                (
                    Id,
                    Nombre,
                    Apellido,
                    Dni,
                    Email,
                    Perfiles,
                    CreatedAt,
                    UpdatedAt
                )
                VALUES
                (
                    @Id,
                    @Nombre,
                    @Apellido,
                    @Dni,
                    @Email,
                    @Perfiles,
                    @CreatedAt,
                    @UpdatedAt
                )
            """;

            await connection.ExecuteAsync(sql, usuario);
        }

        public async Task<Usuario?> ObtenerPorId(long id)
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                SELECT *
                FROM Usuarios
                WHERE Id = @Id
            """;

            return await connection
                .QueryFirstOrDefaultAsync<Usuario>(
                    sql,
                    new { Id = id }
                );
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            using var connection =
                _connection.CreateConnection();

            string sql = """
                        SELECT *
                        FROM Usuarios
                        """;

            return await connection
                .QueryAsync<Usuario>(sql);
        }
        public async Task<bool> Actualizar(Usuario usuario)
        {
            using var connection = _connection.CreateConnection();

            string sql = """
        UPDATE Usuarios
        SET
            Nombre = @Nombre,
            Email = @Email,
            Password = @Password
        WHERE Id = @Id
    """;

            int filasAfectadas = await connection.ExecuteAsync(sql, usuario);

            return filasAfectadas > 0;
        }


    }
}