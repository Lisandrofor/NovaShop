using System.Security.Cryptography.X509Certificates;

namespace NovaShop.Models
{
// ── Entidad principal ─────────────────────────
    public record Usuario {
        public long Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Apellido { get; init; }
        public long Dni { get; init; }
        public string Email { get; init; }
        public string CreatedAt { get; init; } = string.Empty;
        public string? UpdatedAt { get; init; }

        public Perfiles Perfiles { get; set; }=new Perfiles();
                        
    
    }

// ── Request para crear un Usuario (POST) ─────────────────────────────────────
       public record CreateUserRequest( 
        Guid Id,

       bool Activo,

        string Email);
// ── Request para actualizar un Usuario (PUT) ─────────────────────────────────
    public record UpdateUserRequest( 
    string Name,

    string? Apellido,

    string rol);



}
// ---DTO Usuarios
public class UsuarioDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Activo { get; set; }
}

