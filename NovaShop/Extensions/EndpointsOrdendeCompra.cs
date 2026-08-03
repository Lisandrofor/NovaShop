using NovaShop.Interfaces.Repositories;
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
            app.MapGet("/OrdenesCompra", async (ICompraRepository repo) =>
            {
                var ordenComp = await repo.ObtenerOrdenesComp();
                return Results.Ok(ordenComp);
            })
.WithTags("OrdenesCompra");

            // GET by id
            app.MapGet("/OrdenComp/{id}", async (long id, ICompraRepository repo) =>
            {
                var ordenesComp = await repo.ObtenerOrdenesComp();
                var orden = ordenesComp.FirstOrDefault(i => i.IdOrdenCompra == id);
                return orden is not null ? Results.Ok(orden) : Results.NotFound();
            })
.WithTags("Orden");

            // POST
            app.MapPost("/OrdenComp", async (
    CreateOrdenRequest req,
    ICompraRepository repo) =>
            {
                var orden = new OrdenCompras
                {
                    IdUsuario = req.IdUsuario,
                    FechaCompra = DateTime.Now,
                    Items=req.items
                };

                await repo.AgregarOrdenes(orden);

                return Results.Created(
                    $"/OrdenComp/{orden.IdOrdenCompra}",
                    orden
                );
            })
.WithTags("OrdenCompras");

            

            // DELETE
            app.MapDelete("/OrdenComp/{id}", async (long id, ICompraRepository repo) =>
            {
                var orden = await repo.ObtenerOrdenPorId(id);

                if (orden is null)
                    return Results.NotFound("Orden no encontrada.");

               

                await repo.EliminarOrden(id);

                return Results.Ok();
            })
.WithTags("OrdenComp");
        }
    }
}
