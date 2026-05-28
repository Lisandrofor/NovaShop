using NovaShop.Models;

namespace NovaShop.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task CrearUsuario(Usuario usuario);
    
    Task GuardarUsuario(Usuario usuario);
 Task Actualizar(Usuario usuario);
Task EliminarUsuario(long ID);
    
    
    
    
    
    
    }
}
