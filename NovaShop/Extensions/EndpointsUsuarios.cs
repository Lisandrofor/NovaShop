using Microsoft.CodeAnalysis.CSharp.Syntax;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;
using Serilog;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NovaShop.Extensions
{
    public static class EndpointsUsuarios
    { static
        public void MapUserEndpoints(this WebApplication app)
        {

            var idCounter = 1L;

            // GET all
            app.MapGet("/usuarios", async (IUsuarioRepository repo) =>
            {
                var usuarios = await repo.ObtenerUsuarios();

                return Results.Ok(usuarios);
            })
.WithTags("Usuarios");

            // GET by id
            app.MapGet("/usuarios/{id}", async (long id, IUsuarioRepository repo) =>
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
                    Password = req.Password,

                };

                await service.CrearUsuario(usuario);

                return Results.Ok(usuario);


            })
.WithTags("Usuarios");

            // PUT
            app.MapPut("/usuarios/{id}", async (long id, IUsuarioRepository repo, UpdateUserRequest req) =>
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


                await repo.ActualizarUsuario(actualizado);

                return Results.Ok(actualizado);
            })
.WithTags("Usuarios");






            // DELETE
            app.MapDelete("/usuarios/{id}", async (long id,IUsuarioRepository repo) =>
            {
                var usuario = await repo.ObtenerPorId(id);

                if (usuario is null)
                    return Results.NotFound();

                await repo.EliminarUsuario(id);

                return Results.NoContent();
            });


            // LOGIN
            app.MapPost("/login", async (CreateUserLoginRequest req, IAuthService service) =>
                {
                    var log = new Login
                    {

                        Email = req.Email,
                        Password = req.Password,

                    };

                    bool ok = await service.Login(log);

                    if (!ok)
                        return Results.Unauthorized();

                    return Results.Ok("Login correcto");
                })
.WithTags("login");

        }
    }
}


