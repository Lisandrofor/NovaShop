using NovaShop.Models;


namespace NovaShop.Interfaces.Repositorios
{
    public interface IUsuarioRepository
    {
        
            Task<bool> ExisteEmail(string email);

            Task Guardar(Usuario usuario);

               Task<IEnumerable<Usuario>> ObtenerUsuarios();
                Task<Usuario?> ObtenerPorId(long id);
                Task Actualizar(Usuario usuario);
                Task Eliminar(long id);

    }
}
