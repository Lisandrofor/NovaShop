using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;

namespace NovaShop.Services.Usuarios

{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
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