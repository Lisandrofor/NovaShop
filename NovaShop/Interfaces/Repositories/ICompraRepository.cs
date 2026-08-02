using NovaShop.Models;
namespace NovaShop.Interfaces.Repositories
{
    public interface ICompraRepository
    {

        Task<IEnumerable<OrdenCompras>> ObtenerOrdenesComp();
        Task<OrdenCompras?> ObtenerOrdenPorId(long id);
        Task AgregarOrdenes(OrdenCompras orden);
    }
}
