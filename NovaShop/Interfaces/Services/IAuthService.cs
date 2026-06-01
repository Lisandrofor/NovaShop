using NovaShop.Models;

namespace NovaShop.Interfaces.Services
{
    public interface IAuthService
    {
        Task<bool> Login(Login login);
    }
}
