namespace NovaShop.Models
{
    public record Carrito
    {
        public Guid IdCarrito { get; set; }

        public Guid IdUsuario { get; set; }

        // Lista de productos del carrito
        public List<ItemCarrito> Items { get; set; } = new();

        // Suma total del carrito
        public decimal Subtotal => Items.Sum(i => i.Total);

        // Cantidad total de productos
        public int CantidadTotal => Items.Sum(i => i.Cantidad);
    }
}