using NovaShop.Models;

namespace NovaShop.Interfaces.Repositorios
{
    public class IUsuarioRepository
    {
        
            Task<bool> ExisteEmail(string email);

            Task Guardar(Usuario usuario);
        
     }
}
