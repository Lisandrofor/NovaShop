namespace NovaShop.Models
{
    public record OrdenCompras
    {
        public long IdOrdenCompra { get; set; }
        public long IdUsuario { get; set; }
        public List<ItemCarrito> Items { get; set; } = new();
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        // Suma total de la orden de compra
        public decimal Total => Items.Sum(i => i.SubTotal);
        // Cantidad total de productos en la orden de compra
        public int CantidadTotal => Items.Sum(i => i.Cantidad);
    }
}
