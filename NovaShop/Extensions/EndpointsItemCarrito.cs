using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;
using NovaShop.Repositories;


namespace NovaShop.Extensions
{
    public static class EndpointsItemCarrito 
    { static
        public void MapItemEndpoints(this WebApplication app)
        {
            
           

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
            app.MapPost("/carritos/{idCarrito}/items", async (long idCarrito,CreateItemRequest req,ICarritoRepository carritoRepo,IProductosRepository productoRepo) =>
            {
                var carrito = await carritoRepo.ObtenerPorId(idCarrito);

                if (carrito is null)
                    return Results.NotFound("Carrito no encontrado.");

                var producto = await productoRepo.ObtenerProductoId(req.IdProducto);

                if (producto is null)
                    return Results.NotFound("Producto no encontrado.");

                var item = new ItemCarrito
                {
                    IdCarrito = idCarrito,
                    IdProducto = req.IdProducto,
                    Cantidad = req.Cantidad,
                    Producto = producto,
                    CreatedAt = DateTime.UtcNow
                };

                await carritoRepo.AgregarItemCarrito(item);

                return Results.Created($"/carritos/{idCarrito}/items/{item.IdItemCarrito}", item);
            });

            // PUT
            app.MapPut("/carritos/{idCarrito}/items/{idItem}", async (long idCarrito,long idItem,UpdateItemRequest request,ICarritoRepository repo) =>
 {
     var carrito = await repo.ObtenerPorId(idCarrito);

     if (carrito is null)
         return Results.NotFound("Carrito no encontrado.");

     var item = carrito.Items.FirstOrDefault(i => i.IdItemCarrito == idItem);

     if (item is null)
         return Results.NotFound("Item no encontrado.");

     await repo.ActualizarItemCarrito(idItem, request);

     return Results.NoContent();
 });

            // DELETE
            app.MapDelete("/itemCarrito/{id}", async (long id, ICarritoRepository repo) =>
            {
                var carrito= await repo.ObtenerPorId(id);

                if (carrito is null)
                    return Results.NotFound("Carrito no encontrado.");
                
                var item = carrito.Items.FirstOrDefault(i => i.IdItemCarrito == id);

                if (carrito is null)
                    return Results.NotFound();

                await repo.EliminarItemCarrito(id);

                return Results.Ok();
            })
.WithTags("ItemsCarrito");
        }




    }
}