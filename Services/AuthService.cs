using InventarioBackend.Data;
using InventarioBackend.Helpers;
using Microsoft.EntityFrameworkCore;

namespace InventarioBackend.Services
{    

    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || user.Password != password) return null; // In a real scenario, hash password

            var token = JwtHelper.GenerateJwtToken(user);

            return token;
        }
    }
}
