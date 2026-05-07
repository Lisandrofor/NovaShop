namespace NovaShop.Models
{
// ── Entidad principal ─────────────────────────
    public record Usuarios {
        public long Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Apellido { get; init; }
        public long Dni { get; init; }
        public string Email { get; init; }
        public string CreatedAt { get; init; } = string.Empty;
        public string? UpdatedAt { get; init; }
                        }

// ── Request para crear un Usuario (POST) ─────────────────────────────────────
       public record CreateUserRequest( 
        string Name,

        string? Apellido,

        long Dni,

        string Email);
// ── Request para actualizar un Usuario (PUT) ─────────────────────────────────
    public record UpdateUserRequest( 
    string Name,

    string? Apellido,

    string rol);



}
