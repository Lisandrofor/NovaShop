using NovaShop.Models;

namespace NovaShop.Extensions
{
    public static class EndpointsOrdenVent 
    { static
        public void MapItemEndpoints(this WebApplication app)
        {
            var productos = new List<Productos>();
            var idCounter = 1L;

            // GET all
            app.MapGet("/productos", () =>
            {
                return Results.Ok(productos);
            })
.WithTags("Productos");

            // GET by id
            app.MapGet("/productos/{id}", (long id) =>
            {
                var producto = productos.FirstOrDefault(i => i.Id == id);
                return producto is not null ? Results.Ok(producto) : Results.NotFound();
            })
.WithTags("Productos");

            // POST
            app.MapPost("/productos", (CreateItemRequest req) =>
            {
                var producto = new Productos
                {
                    Id = idCounter++,
                    Name = req.Name,
                    Description = req.Description,
                    Price = (double)req.Price,
                    Stock = req.Stock,
                    CreatedAt = DateTime.UtcNow.ToString("o")
                };

                items.Add(producto);

                return Results.Ok(producto);
            })
.WithTags("Productos");

            // PUT
            app.MapPut("/productos/{id}", (long id, UpdateItemRequest req) =>
            {
                var existing = usuarios.FirstOrDefault(i => i.Id == id);

                if (existing is null)
                    return Results.NotFound();

                var updated = existing with
                {
                    Name = req.Name,
                    Description = req.Description,
                    Price = (double)req.Price,
                    Stock = req.Stock,
                    UpdatedAt = DateTime.UtcNow.ToString("o")
                };

                items.Remove(existing);
                items.Add(updated);

                return Results.Ok(updated);
            })
.WithTags("Productos");

            // DELETE
            app.MapDelete("/productos/{id}", (long id) =>
            {
                var producto = productos.FirstOrDefault(i => i.Id == id);

                if (producto is null)
                    return Results.NotFound();

                productos.Remove(producto);

                return Results.Ok();
            })
.WithTags("Productos");
        }




    }
}