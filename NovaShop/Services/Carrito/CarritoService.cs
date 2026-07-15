using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;



namespace NovaShop.Services.Carrito
{
    public class CarritoService: ICarritoService
    {
        private readonly ICarritoRepository _repository;
    }
}
