using NovaShop.Models;


namespace NovaShop.Interfaces.Repositorios
{
    public interface IUsuarioRepository
    {
        
            Task<bool> ExisteEmail(string email);
Task<bool> ExisteDNI (long dni);

            Task Guardar(Usuario usuario);

               Task<IEnumerable<Usuario>> ObtenerUsuarios();
                Task<Usuario?> ObtenerPorId(long id);
                Task Actualizar(Usuario usuario);
                Task EliminarUsuario(long id);

    }
}
