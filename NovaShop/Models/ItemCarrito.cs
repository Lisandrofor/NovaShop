namespace NovaShop.Models
{
    public record ItemCarrito
    {
        public Guid IdProducto { get; set; }

        public Producto Producto { get; set; } = new();

        public int Cantidad { get; set; }

        // Precio total de ESTE producto
        public decimal Total => Producto.Precio * Cantidad;
    }
}