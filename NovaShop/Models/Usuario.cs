using System.Security.Cryptography.X509Certificates;

namespace NovaShop.Models
{
    // ── Entidad principal ─────────────────────────
    public record Usuario
    {
        public long Id { get; init; }
        public string Nombre { get; set; } = string.Empty;
        public string? Apellido { get; init; }
        public long Dni { get; init; }
        public string? Email { get; init; }
        public bool  Activo { get; init; }
        public string Password { get; init; }
        public string Username { get; init; } = string.Empty;
        public string PasswordHash { get; init; } = string.Empty;
        public string PasswordReset { get; init; } = string.Empty;
        public string CreatedAt { get; init; } = string.Empty;
        public string? UpdatedAt { get; init; }

        public Perfiles Perfiles { get; set; } = new Perfiles();


    }

    // ── Request para crear un Usuario (POST) ─────────────────────────────────────
    public record CreateUserRequest(
    string Nombre,
    string Apellido,
    long Dni,
    string Email,
    string Password);
    // ── Request para actualizar un Usuario (PUT) ─────────────────────────────────
    public record UpdateUserRequest(
    string Nombre,

    string? Apellido,

    string Email,
    string Password);




    // ---DTO Usuarios
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    }

}