namespace NovaShop.Models
{
    public record OrdenVentas
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public List<ItemVentas> Items { get; set; } = new List<ItemVentas>();
        public decimal Total { get; set; }
        public EstadoOrden Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

}
