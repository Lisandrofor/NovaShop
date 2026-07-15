using NovaShop.Models;


namespace NovaShop.Interfaces.Repositorios
{
    public interface ICarritoRepository
    {

        Task<IEnumerable<Carrito>> ObtenerCarritos();

        Task<bool> ExisteCarrito(long id);

        Task GuardarProducto(Carrito carrito);
    }
}