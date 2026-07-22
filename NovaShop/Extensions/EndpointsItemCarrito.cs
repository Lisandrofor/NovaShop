
using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;


namespace NovaShop.Extensions
{
    public static class EndpointsItemCarrito 
    { static
        public void MapItemEndpoints(this WebApplication app)
        {
            
            var idCounter = 1L;

            // GET all
            app.MapGet("/itemscarrito",async (ICarritoRepository repo) =>
            {
                var itemscarrito = await repo.ObtenerCarritos();
                return Results.Ok(itemscarrito);
            })
.WithTags("ItemsCarrito");

            // GET by id
            app.MapGet("/itemscarrito/{id}", async (long id, ICarritoRepository repo) =>
            {
                var itemscarrito = await repo.ObtenerCarritos();
                var items = itemscarrito.FirstOrDefault(i => i.IdCarrito == id);
                return items is not null ? Results.Ok(items) : Results.NotFound();
            })
.WithTags("ItemsCarrito");

            // POST
            app.MapPost("/itemCarrito", (CreateItemRequest req) =>
            {
                var itemCarrito = new ItemCarrito
                {
                    Id = idCounter++,
                    IdProducto = req.idProducto,
                    IdCarrito= req.IdCarrito,
                    Cantidad = req.Cantidad,
                    Producto = producto, 
                    CreatedAt = DateTime.UtcNow.ToString("o")
                };

                items.Add(itemCarrito);

                return Results.Ok(itemCarrito);
            })
.WithTags("ItemCarrito");

            // PUT
            app.MapPut("/itemCarrito/{id}", (long id, UpdateItemRequest req) =>
            {
                var itemsCarrito= await repo.ObtenerCarritos();
                var existing = itemsCarrito.FirstOrDefault(i => i.Id == id);

                if (existing is null)
                    return Results.NotFound();

                var updated = existing with
                {
                    IdProducto=req.idProducto,
                    Cantidad= req.cantidad,
                    Producto= producto 
                    UpdatedAt = DateTime.UtcNow.ToString("o")
                };

                items.Remove(existing);
                items.Add(updated);

                return Results.Ok(updated);
            })
.WithTags("ItemCarrito");

            // DELETE
            app.MapDelete("/itemCarrito/{id}", (long id) =>
            {
                var itemsCarrito= await repo.ObtenerCarritos();
                var carrito = itemsCarrito.FirstOrDefault(i => i.Id == id);

                if (carrito is null)
                    return Results.NotFound();

                itemsCarrito.Remove(carrito);

                return Results.Ok();
            })
.WithTags("ItemsCarrito");
        }




    }
}