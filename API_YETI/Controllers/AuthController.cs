using Microsoft.AspNetCore.Mvc;
using API_YETI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API_YETI.Data;
using API_YETI.DTOs;

namespace API_YETI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController (AppDbContext context) 
        {
            _context = context;
        }

        // Registro novo usuário:
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userDto)
        {
            if (userDto == null) 
            {
                return BadRequest("Dados inválidos!");
            }

            // verifica se o usuário já existe pelo e-mail:
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (existingUser != null) 
            {
                return BadRequest("O e-mail já está em uso.");
            }

            // criação do usuario:
            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password), // criptografa a senha
                Role = "User",  // atribui a role padrão
                DataCreationAccount = DateTime.UtcNow // atribui a data de criação
            };

            // o 'user' deve vir de padrão com role + data creation
            // adicionar usuário dentro do banco de dados:
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuário cadastrado com sucesso!", userId = user.Id });
        }
    }
}
