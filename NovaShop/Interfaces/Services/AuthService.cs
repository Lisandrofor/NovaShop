using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;

public class AuthService
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
        return passwordIngresada == passwordHash;
    }
}