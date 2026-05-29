using NovaShop.Interfaces.Services;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            app.MapPut("/usuarios/{id}", async (long id, IUsuarioRepository repo,UpdateUserRequest req) =>
            {
                
                var usuario = await repo.ObtenerPorId(id);
                
                if (usuario is null)
                    return Results.NotFound();
                
                
                var actualizado = usuario with
                {
                    Nombre = req.Nombre,
                    Apellido = req.Apellido,
                    Email = req.Email,
                    Password = req.Password
                };
                

                await repo.Actualizar(actualizado);

                return Results.Ok(actualizado);
            })
.WithTags("Usuarios");



            


            // DELETE
            app.MapDelete("/usuarios/{id}", async (long id,IUsuarioRepository repo) =>
            {
                var usuarios = await repo.ObtenerUsuarios();

                var usuario = usuarios.FirstOrDefault(i => i.Id == id);
                return usuario is not null ?
                await repo.EliminarUsuario(id):
                Results.NotFound();

            })
.WithTags("Usuarios");
        }




    }
}
