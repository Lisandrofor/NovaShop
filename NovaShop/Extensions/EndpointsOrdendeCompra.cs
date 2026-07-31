using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;


namespace NovaShop.Extensions
{
    public static class EndpointsOrdendeCompra
    {
        static
        public void MapEndpointsOrdenCompra(this WebApplication app)
        {



            // GET all
            app.MapGet("/ordenesCompra", async (ICompraRepository repo) =>
            {
                var ordenComp = await repo.ObtenerOrdenesComp();
                return Results.Ok(ordenComp);
            })
.WithTags("OrdenesCompra");

            // GET by id
            app.MapGet("/OrdenComp/{id}", async (long id, ICompraRepository repo) =>
            {
                var carritos = await repo.ObtenerCarritos();
                var carrito = carritos.FirstOrDefault(i => i.IdCarrito == id);
                return carritos is not null ? Results.Ok(carritos) : Results.NotFound();
            })
.WithTags("Carritos");

            // POST
            app.MapPost("/Carrito", async (
    CreateCarritoRequest req,
    ICarritoRepository repo) =>
            {
                var carrito = new Carrito
                {
                    IdUsuario = req.IdUsuario,
                    FechaAgregado = DateTime.Now
                };

                await repo.AgregarCarrito(carrito);

                return Results.Created(
                    $"/Carrito/{carrito.IdCarrito}",
                    carrito
                );
            })
.WithTags("Carrito");

            // PUT
            app.MapPut("/carritos/{idCarrito}/items/{idItem}", async (long idCarrito, long idItem, UpdateItemRequest request, ICarritoRepository repo) =>
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
                var carrito = await repo.ObtenerPorId(id);

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
