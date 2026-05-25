using NovaShop.Models;


namespace NovaShop.Interfaces.Repositorios
{
    public interface IProductosRepository
    {

        Task<bool> ExisteStock(string stock);

        Task Guardar(Producto producto);

    }
}