namespace NovaShop.Models
{
    public record Carrito
    {
        public long IdCarrito { get; set; }

        public long IdUsuario { get; set; }

        // Lista de productos del carrito
        public List<ItemCarrito> Items { get; set; } = new();
        public DateTime FechaAgregado { get; set; } = DateTime.Now;

        // Suma total del carrito
        public decimal Total => Items.Sum(i => i.SubTotal);

        // Cantidad total de productos
        public int CantidadTotal => Items.Sum(i => i.Cantidad);
    }
}