namespace NovaShop.Models
{
    public class ItemVentas
    {

        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
        public enum EstadoOrden
        {
            Pendiente,
            Pagada,
            Enviada,
            Entregada,
            Cancelada
        }
    }



