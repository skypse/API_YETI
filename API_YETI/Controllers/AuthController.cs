using Microsoft.AspNetCore.Mvc;
using API_YETI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API_YETI.Data;

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
        public async Task<IActionResult> Register([FromBody] User user) 
        {
            if (user == null) 
            {
                return BadRequest("Usuário inválido!");
            }

            // verifica se o usuário já existe pelo e-mail
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null) 
            {
                return BadRequest("O e-mail já está em uso.");
            }

            // o 'user' deve vir de padrão com role + data creation
            // adicionar usuário dentro do banco de dados
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuário cadastrado com sucesso!");
        }
    }
}
