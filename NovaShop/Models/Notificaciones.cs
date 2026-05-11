namespace NovaShop.Models
{
   
        public record Notificacion
        {
            public Guid Id { get; set; }
            public Guid UsuarioId { get; set; }
            public string Mensaje { get; set; }
            public TipoNotificacion Tipo { get; set; }
            public DateTime FechaEnvio { get; set; }
            public bool Enviada { get; set; }
        }

        public enum TipoNotificacion
        {
            Email,
            SMS,
            Push
        }

    
}
