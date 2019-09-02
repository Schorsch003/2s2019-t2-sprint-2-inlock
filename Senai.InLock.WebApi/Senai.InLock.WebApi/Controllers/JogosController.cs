using System;
using System.Collections.Generic;
using System.Linq;
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
    public class JogosController : ControllerBase {

        JogoRepository jogoRepository = new JogoRepository();
        
        [HttpGet]
        public IEnumerable<Jogos> Listar () {
            return jogoRepository.ListarJogos();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id) {
            try {
                var jogo = jogoRepository.BuscarPorId(id);
                if (jogo == null) {
                    return NotFound(new { message = "Jogo não encontrado" });
                }
                return Ok(jogo);
            } catch (Exception ex) {
                return BadRequest(new { message = "Erro : " + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult CadastrarJogo (Jogos jogo) {
            try {
                jogoRepository.Cadastrar(jogo);
                return Ok(new { message = "Jogo cadastrado com sucesso!" });
            } catch (Exception ex) {
                return BadRequest(new { message = "Erro ao cadastrar: " + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult AtualizarJogo (int id , Jogos jogo) {
            try {
                jogoRepository.Atualizar(id , jogo);
                return Ok(new { message = "Jogo atualizado com sucesso" });
            } catch (Exception ex) {
                return BadRequest(new { message = "Erro: " + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id) {
            try {
                jogoRepository.RemoverJogo(id);
                return Ok(new { message = "Jogo removido com sucesso" });
            }catch(Exception ex) {
                return BadRequest(new { message = "Erro: " + ex.Message });
            }

        }

    }
}