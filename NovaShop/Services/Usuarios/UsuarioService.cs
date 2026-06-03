using Humanizer;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;

namespace NovaShop.Services.Usuarios

{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUsuarioRepository repository, ILogger<UsuarioService> logger)
        {
            _repository = repository;
            _logger = logger;
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
            if 
            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            await _repository.Guardar(usuario);
        }


        public async Task GuardarUsuario(Usuario usuario)
        {
            bool existe = await _repository.ExisteDNI(usuario.Dni);
            if (existe)
            {
                throw new Exception("El Usuario ya existe");
            }
            await _repository.Guardar(usuario);

        }

        public async Task Actualizar(long id, UpdateUserRequest dto)
        {
            var usuario = await _repository.ObtenerPorId(id);

            if (usuario is null)
            {
                _logger.LogWarning(
                    "Intento de actualizar usuario inexistente {Id}",
                    id);

                throw new Exception("Usuario no encontrado");
            }

            bool emailExiste =
                await _repository.ExisteEmail(dto.Email);

            if (emailExiste && !usuario.Email.Equals(dto.Email,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("El email ya existe");
            }

            var usuarioActualizado = new Usuario
            {
                Id = usuario.Id,
                Nombre = dto.Nombre,
                Email = dto.Email
            };

            await _repository.ActualizarUsuario(usuarioActualizado);

            _logger.LogInformation(
                "Usuario {Id} actualizado correctamente",
                id);
        }

        public async Task EliminarUsuario(long id)
        {
            var usuario = await _repository.ObtenerPorId(id);

            if (usuario is null)
            {
                _logger.LogWarning(
                    "Se intentó eliminar el usuario {Id} pero no existe",
                    id);

                throw new Exception("Usuario no encontrado");
            }

            await _repository.EliminarUsuario(id);

            _logger.LogInformation(
                "Usuario {Id} eliminado correctamente",
                id);
        }


    }
}
       
        