using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class EstudiosController : ControllerBase {

        EstudioRepository estudioRepository = new EstudioRepository();

        
        [HttpGet]
        public IEnumerable<Estudios> ListarEstudios () {
            return estudioRepository.ListarEstudios();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id) {
            try {

                return Ok(estudioRepository.BuscarPorId(id));
            }catch(Exception ex) {
                return BadRequest(new { message = "Erro: " + ex.Message });
            }
        }
        
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio) {
            try{
                estudioRepository.CadastrarEstudio(estudio);
                return Ok(new { message = "Estúdio cadastrado com sucesso ^-^ " });
            } catch (Exception ex) {
                return BadRequest(new { message = "Erro: " + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult AtualizarEstudio(int id,Estudios estudio) {
            try {
                estudioRepository.Atualizar(id , estudio);
                return Ok(new { message = "Estúdio cadastrado com sucesso" });
            }catch(Exception ex) {
                return BadRequest(new { message = "Erro: " + ex.Message});
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult RemoverEstudio(int id) {
            try {
                estudioRepository.RemoverEstudio(id);
                return Ok(new { message = "Estúdio removido com sucesso" });
            }catch(Exception ex) {
                return BadRequest(new { message = "Erro: " + ex.Message });
            }
        }

        [Authorize]
        [HttpGet("buscarnome/{nome}")]
        public IActionResult BuscarPorNome(string nome) {
            return Ok(estudioRepository.BuscarPorNome(nome));
        }

        [HttpGet("buscarpais/{pais}")]
        public IEnumerable<Estudios> BuscarPorPais(string pais) {
            return estudioRepository.BuscarPorPais(pais);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("estudiosinseridos")]
        public IEnumerable<Estudios> EstudiosAdicionadosPorAdmin () {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var id = Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

            return estudioRepository.EstudiosInseridosPor(id);
        }
    }
}