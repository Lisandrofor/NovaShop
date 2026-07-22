namespace NovaShop.Models
{
    public record ItemCarrito
    {
        
        public long IdItemCarrito { get; set; }
        public long IdProducto { get; set; }

        public long IdCarrito { get; set; }

        public Producto Producto { get; set; } = new();

        public int Cantidad { get; set; }

        // Precio total de ESTE producto
        public decimal SubTotal => Producto.Precio * Cantidad;

        public record CreateItemRequest(
        long Idproducto,
        long IdCarrito,
        int Cantidad
        
        );

    }
}