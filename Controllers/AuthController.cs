using InventarioBackend.DTOs;
using InventarioBackend.Models;
using InventarioBackend.Services;
using InventarioBackend.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace InventarioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _authService.Authenticate(loginDto.Username, loginDto.Password);
            if (token == null)
            {
                return Unauthorized(new ErrorResponse("Autenticación fallida", "Credenciales inválidas"));
            }
            return Ok(new { Token = token });
        }
    }
}
