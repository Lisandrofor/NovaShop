using NovaShop.Data;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;
using System;
using Dapper;

namespace NovaShop.Repositories
{
    public class ProductoRepository : IProductosRepository
    {
        public readonly DatabaseInitializer _databaseInitializer;
        // GET ALL 

        public async Task<IEnumerable<Producto>> GetAllAsync()

        {

            using var conn = CreateConnection();

            return await conn.QueryAsync<Producto>(""" 

        SELECT id, name, description, price, stock, 

               created_at AS CreatedAt, updated_at AS UpdatedAt 

        FROM items ORDER BY id DESC 

    """);

        }



        // CREATE 

        public async Task<Item> CreateAsync(CreateItemRequest request)

        {

            using var conn = CreateConnection();

            var id = await conn.ExecuteScalarAsync<int>(""" 

        INSERT INTO items (name, description, price, stock) 

        VALUES (@Name, @Description, @Price, @Stock); 

        SELECT last_insert_rowid(); 

    """, request);

            return (await GetByIdAsync(id))!;

        }

    }
}