using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories {
    public class EstudioRepository {

        public List<Estudios> ListarEstudios () {
            using (InLockContext ctx = new InLockContext()) {
                return ctx.Estudios.ToList();
            }
        }

        public Estudios BuscarPorId (int id) {
            using (InLockContext ctx = new InLockContext()) {
                return ctx.Estudios.Find(id);
            }
        }

        public void CadastrarEstudio (Estudios estudio) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(int id, Estudios estudio) {
            using (InLockContext ctx = new InLockContext()) {
                var studio = BuscarPorId(id);
                if(estudio.NomeEstudio != null) {
                    studio.NomeEstudio = estudio.NomeEstudio;
                }
                if(estudio.PaisOrigem != null) {
                    studio.PaisOrigem = estudio.PaisOrigem;
                }
                if(estudio.DataCriacao != null) {
                    studio.DataCriacao = estudio.DataCriacao;
                }
                ctx.Update(studio);
                ctx.SaveChanges();
            }
        }

        public void RemoverEstudio(int id) {
            using (InLockContext ctx = new InLockContext()) {
                var estudio = BuscarPorId(id);
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }
    }
}
