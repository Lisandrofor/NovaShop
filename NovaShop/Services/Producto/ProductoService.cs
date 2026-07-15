using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;


namespace NovaShop.Services.Productos
{
    public class ProductoService : IProductoService
    {
        private readonly IProductosRepository _repository;
       

        public ProductoService(IProductosRepository repository)
        {
            _repository = repository;
            
        }

        public async Task CrearProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Descripcion))
            {
                throw new Exception("La descripcion es obligatoria");
            }

            if (producto.Stock < 0)
            {
                throw new Exception("La Cantidad de Productos debe ser mayor a 0");
            }

            await _repository.GuardarProducto(producto);

        }
        public async Task GuardarProducto(Producto producto)
        {
            bool existe = await _repository.ExisteProducto(producto.Id);
            if (existe)
            {
                throw new Exception("El Usuario ya existe");
            }
            await _repository.GuardarProducto(producto);

        }


    }
}
