using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;

namespace NovaShop.Services.Usuarios

{
    public class UsuarioService : IUsuarioService
        {
            private readonly IUsuarioRepository _repository;

            public UsuarioService(IUsuarioRepository repository)
            {
                _repository = repository;
            }

            public async Task CrearUsuario(Usuario usuario)
            {
                if (string.IsNullOrWhiteSpace(usuario.Nombre))
                {
                    throw new Exception("El nombre es obligatorio");
                }

                if (usuario.Edad < 18)
                {
                    throw new Exception("Debe ser mayor de edad");
                }

                bool existe = await _repository.ExisteEmail(usuario.Email);

                if (existe)
                {
                    throw new Exception("El email ya existe");
                }

                await _repository.Guardar(usuario);
            }
        }

public async Task 
GuardarUsuario(Usuario usuario)
{ bool existe = await _repository.ExisteDNI(usuario.Email);
if ( existe)
{
throw new Exception("El Usuario ya existe");
}
await _repository.Guardar(usuario);
}