using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories {
    public class JogoRepository {

        public List<Jogos> ListarJogos () {
            using (InLockContext ctx = new InLockContext()) {
                return ctx.Jogos.Include(x => x.Estudio).ToList();
            }
        }

        public Jogos BuscarPorId (int id) {
            using (InLockContext ctx = new InLockContext()) {
                return ctx.Jogos.Find(id);
            }
        }

        public void Cadastrar (Jogos jogo) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar (int id , Jogos jogo) {
            using (InLockContext ctx = new InLockContext()) {
                Jogos game = BuscarPorId(id);
                if (jogo.NomeJogo != null) {
                    game.NomeJogo = jogo.NomeJogo;
                }
                if (jogo.Descricao != null) {
                    game.Descricao = jogo.Descricao;
                }
                if (jogo.DataLancamento != null) {
                    game.DataLancamento = jogo.DataLancamento;
                }
                if (jogo.Valor != null) {
                    game.Valor = jogo.Valor;
                }
                ctx.Update(game);
                ctx.SaveChanges();
            }
        }

        public void RemoverJogo (int id) {
            using (InLockContext ctx = new InLockContext()) {
                var jogo = BuscarPorId(id);
                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }

    }
}
