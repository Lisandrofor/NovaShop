using NovaShop.Models;

namespace NovaShop.Interfaces.Services
{
    public interface IProductoService
    {
        Task CrearProducto(Producto producto);
        Task GuardarProducto (Producto producto);

    }
}
