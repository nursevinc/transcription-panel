using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranscriptionAPI.Services;
using System.Security.Cryptography;
using System.Text;
using TranscriptionAPI.Model;

namespace TranscriptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;
        private readonly LogService _logService;

        public AuthController(AppDbContext context, JwtService jwtService, LogService logService)
        {
            _context = context;
            _jwtService = jwtService;
            _logService = logService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null) return Unauthorized("Kullanıcı bulunamadı.");

            var hashedPassword = HashPassword(request.Password);
            if (user.PasswordHash != hashedPassword)
                return Unauthorized("Şifre yanlış.");

            var token = _jwtService.GenerateToken(user);

            //  Giriş yapıldı log kaydı
            await _logService.LogAction(user.Id.ToString(), $"{user.Username} giriş yaptı");

            return Ok(new { token });
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
