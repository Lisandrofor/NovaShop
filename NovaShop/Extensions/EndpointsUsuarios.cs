using NovaShop.Interfaces.Services;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NovaShop.Extensions
{
    public static class EndpointsUsuarios
    { static
        public void MapUserEndpoints(this WebApplication app)
        {
           
            var idCounter = 1L;

            // GET all
            app.MapGet("/usuarios",async (IUsuarioRepository repo) =>
            {
                var usuarios = await repo.ObtenerUsuarios();

                return Results.Ok(usuarios);
            })
.WithTags("Usuarios");

            // GET by id
            app.MapGet("/usuarios/{id}",async (long id,IUsuarioRepository repo)  =>
            {
                var usuarios = await repo.ObtenerUsuarios();

                var usuario = usuarios.FirstOrDefault(i => i.Id == id);
                return usuario is not null ? 
                Results.Ok(usuario) :
                Results.NotFound();
            })
.WithTags("Usuarios");

            // POST
            app.MapPost("/usuarios", async (CreateUserRequest req, IUsuarioService service) =>
            {
                var usuario = new Usuario
                {
                    Nombre = req.Nombre,
                    Dni = req.Dni,
                    Apellido = req.Apellido,
                    Email = req.Email,
                    Password= req.Password,

                };

                await service.CrearUsuario(usuario);

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
                    Nombre = req.Nombre,
                    Apellido = req.Apellido,
                    Email=req.Email,
                    Password = req.Password,
                    
                };

                usuarios.Remove(existing);
                usuarios.Add(updated);

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
