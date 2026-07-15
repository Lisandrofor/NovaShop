using NovaShop.Models;


namespace NovaShop.Interfaces.Repositorios
{
    public interface IProductosRepository
    {

        Task<IEnumerable<Producto>> ObtenerProductos();

        Task<bool> ExisteProducto(long id);

        Task GuardarProducto(Producto producto);
        Task<Producto?> ObtenerProductoId(long id);
        Task<bool> ActualizarProducto(Producto producto);
        Task EliminarProducto(Guid id);

    }
}