using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;

namespace Senai.InLock.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class LoginController : ControllerBase {

        UsuarioRepository usuarioRepository = new UsuarioRepository();

        [HttpPost]
        public IActionResult Login(LoginViewModel login) {
            try {

                var usuarioRetornado = usuarioRepository.BuscarPorEmailESenha(login);

                if(usuarioRetornado == null) {
                    return NotFound(new { message = "Usuario não encontrado" });
                }

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioRetornado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioRetornado.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, usuarioRetornado.Permissao)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

                var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InLock.WebApi",
                    audience: "InLock.WebApi",
                    claims:claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials:creds            
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            } catch (Exception ex) {
                return BadRequest(new { message = "Erro: " + ex.Message });
            }
        }

        [HttpGet]
        public IEnumerable<Usuarios> ListarUsuarios () {
            return usuarioRepository.Listar();
        }
    }
}