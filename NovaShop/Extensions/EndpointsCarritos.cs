using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;


namespace NovaShop.Extensions
{
    public static class EndpointsCarrito 
    { static
        public void MapEndpoints(this WebApplication app)
        {



            // GET all
            app.MapGet("/carrito",async (ICarritoRepository repo) =>
            {
                var carrito = await repo.ObtenerCarritos();
                return Results.Ok(carrito);
            })
.WithTags("Carrito");

            // GET by id
            app.MapGet("/carrito/{id}", async (long id, ICarritoRepository repo) =>
            {
                var carritos = await repo.ObtenerCarritos();
                var carrito= carritos.FirstOrDefault(i => i.IdCarrito == id);
                return carritos is not null ? Results.Ok(carritos) : Results.NotFound();
            })
.WithTags("Carritos");

            // POST
            app.MapPost("/itemCarrito",async (CreateItemRequest req, Producto produ, ICarritoRepository repo) =>
            {
                var carrito = await repo.ObtenerPorId(req.IdCarrito);

                if (carrito == null)
                    return Results.NotFound("Carrito no encontrado.");


                var itemCarrito = new ItemCarrito
                {

                    IdProducto = req.IdProducto,
                    IdCarrito = req.IdCarrito,
                    Cantidad = req.Cantidad,
                    Producto = produ,
                    CreatedAt = DateTime.UtcNow.ToString("o")
                };


                await repo.AgregarItemCarrito(itemCarrito);

                return Results.Created($"/itemCarrito/{itemCarrito.IdItemCarrito}", itemCarrito);


            })
.WithTags("ItemCarrito");

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