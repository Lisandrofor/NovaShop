using NovaShop.Models;


namespace NovaShop.Interfaces.Repositorios
{
    public interface ICarritoRepository
    {

        Task<IEnumerable<Carrito>> ObtenerCarritos();

        Task<Carrito?> ObtenerPorId(long id);

        Task<bool> ExisteCarrito(long id);

        Task GuardarCarrito(Carrito carrito);

        Task ActualizarItemCarrito(long idItemCarrito, UpdateItemRequest item);

        Task EliminarItemCarrito(long idItemCarrito);

        Task AgregarItemCarrito(ItemCarrito item);
    }
}