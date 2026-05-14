using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;

namespace NovaShop.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> _usuarios = new();

        public Task<bool> ExisteEmail(string email)
        {
            bool existe = _usuarios.Any(u => u.Email == email);

            return Task.FromResult(existe);
        }

        public Task Guardar(Usuario usuario)
        {
            _usuarios.Add(usuario);

            return Task.CompletedTask;
        }
    }
}
