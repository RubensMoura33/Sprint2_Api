using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.inlock.code.First.manha.Interfaces;
using webapi.inlock.code.First.manha.Repositories;
using webapi.inlock.code.First.manha.ViewModels;

namespace webapi.inlock.code.First.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository? _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel usuario)
        {
            Domains.Usuario login  = _usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha);

            if (login == null) 
            {
            return NotFound("Email ou senha invalidos");
            }

            var claims = new[]
            {
                new Claim(JwtRe)
            }
        }
    }
}
