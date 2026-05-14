using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;

namespace NovaShop.Services.Usuario
{
    public class CrearUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public CrearUsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task Crear(UsuarioDto dto)
        {
            bool existe = await _repo.ExisteEmail(dto.Email);

            if (existe)
                throw new Exception("El email ya existe");

            var usuario = new Usuario(dto.Nombre, dto.Email);

            await _repo.Guardar(usuario);
        }
    }
}
