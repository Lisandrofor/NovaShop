using NovaShop.Models;

namespace NovaShop.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task CrearUsuario(Usuario usuario);
    
        Task GuardarUsuario(Usuario usuario);
        Task Actualizar(long id , UpdateUserRequest dto);
        Task EliminarUsuario(long ID);
        
    
    
    
    
    
    
    }
}
