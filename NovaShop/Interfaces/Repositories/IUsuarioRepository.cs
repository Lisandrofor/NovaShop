using NovaShop.Models;

namespace NovaShop.Interfaces.Repositorios
{
    public interface IUsuarioRepository
    {
        
            Task<bool> ExisteEmail(string email);

            Task Guardar(Usuario usuario);
        
     }
}
