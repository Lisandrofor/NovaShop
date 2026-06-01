using NovaShop.Interfaces.Repositorios;
using NovaShop.Interfaces.Services;
using NovaShop.Models;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _repo;

    public AuthService(IUsuarioRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Login(Login login)
    {
        var usuario = await _repo.ObtenerPorEmail(login.Email);

        if (usuario is null)
            return false;

        return VerificarPassword(
            login.Password,
            usuario.PasswordHash);
    }

    private bool VerificarPassword(
     string passwordIngresada,
     string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(
            passwordIngresada,
            passwordHash);
    }
}