using InventarioBackend.Data;
using InventarioBackend.Helpers;

namespace InventarioBackend.Services
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
    }    
}
