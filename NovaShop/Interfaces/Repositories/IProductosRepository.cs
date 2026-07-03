using NovaShop.Models;


namespace NovaShop.Interfaces.Repositorios
{
    public interface IProductosRepository
    {

        Task<IEnumerable<Producto>> ObtenerProductos();

        Task GuardarProducto(Producto producto);
        Task<Producto?> ObtenerProductoId(Guid id);
        Task<bool> ActualizarProducto(Producto producto);
        Task EliminarProducto(Guid id);

    }
}