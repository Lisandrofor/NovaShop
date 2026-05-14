using NovaShop.Models;

namespace NovaShop.Extensions
{
    public static class EndpointsUsuarios
    { static
        public void MapUserEndpoints(this WebApplication app)
        {
            var usuarios = new List<Usuario>();
            var idCounter = 1L;

            // GET all
            app.MapGet("/usuarios", () =>
            {
                return Results.Ok(usuarios);
            })
.WithTags("Usuarios");

            // GET by id
            app.MapGet("/usuarios/{id}", (long id) =>
            {
                var usuario = usuarios.FirstOrDefault(i => i.Id == id);
                return usuario is not null ? Results.Ok(usuario) : Results.NotFound();
            })
.WithTags("Usuarios");

            // POST
            app.MapPost("/usuarios", (CreateUserRequest req) =>
            {
                var usuario = new Usuario
                {
                    Id = idCounter++,
                    Dni=req.Dni,
                    Name = req.Name,
                    Apellido = req.Apellido,
                    Rol = req.Rol,
                    Email = req.Email,
                    CreatedAt = DateTime.UtcNow.ToString("o")
                };

                items.Add(usuario);

                return Results.Ok(usuario);
            })
.WithTags("Usuarios");

            // PUT
            app.MapPut("/usuarios/{id}", (long id, UpdateUserRequest req) =>
            {
                var existing = usuarios.FirstOrDefault(i => i.Id == id);

                if (existing is null)
                    return Results.NotFound();

                var updated = existing with
                {
                    Name = req.Name,
                    Apellido = req.Apellido,
                    Price = (double)req.Price,
                    Stock = req.Stock,
                    UpdatedAt = DateTime.UtcNow.ToString("o")
                };

                items.Remove(existing);
                items.Add(updated);

                return Results.Ok(updated);
            })
.WithTags("Usuarios");

            // DELETE
            app.MapDelete("/usuarios/{id}", (long id) =>
            {
                var usuario = usuarios.FirstOrDefault(i => i.Id == id);

                if (usuario is null)
                    return Results.NotFound();

                usuarios.Remove(usuario);

                return Results.Ok();
            })
.WithTags("Usuarios");
        }




    }
}
