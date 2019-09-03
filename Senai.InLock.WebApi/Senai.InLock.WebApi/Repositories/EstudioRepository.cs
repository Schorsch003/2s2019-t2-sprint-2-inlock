using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories {
    public class EstudioRepository {

        public List<Estudios> ListarEstudios () {
            using (InLockContext ctx = new InLockContext()) {
                return ctx.Estudios.Include(x => x.Jogos).ToList();
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

        public void Atualizar (int id , Estudios estudio) {
            using (InLockContext ctx = new InLockContext()) {
                var studio = BuscarPorId(id);
                if (estudio.NomeEstudio != null) {
                    studio.NomeEstudio = estudio.NomeEstudio;
                }
                if (estudio.PaisOrigem != null) {
                    studio.PaisOrigem = estudio.PaisOrigem;
                }
                if (estudio.DataCriacao != null) {
                    studio.DataCriacao = estudio.DataCriacao;
                }
                ctx.Update(studio);
                ctx.SaveChanges();
            }
        }

        public void RemoverEstudio (int id) {
            using (InLockContext ctx = new InLockContext()) {
                var estudio = BuscarPorId(id);
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }

        public Estudios BuscarPorNome (string nome) {
            using (InLockContext ctx = new InLockContext()) {
                var estudio = nome.Replace('_' , ' ').ToUpper();
                return ctx.Estudios.Include(x => x.Jogos).FirstOrDefault(x => x.NomeEstudio.ToUpper() == estudio);
            }
        }

        public List<Estudios> BuscarPorPais(string pais) {
            using(InLockContext ctx = new InLockContext()) {
                var a = ctx.Estudios.Include(x => x.Jogos).Where(x => x.PaisOrigem.Replace('ã','a').ToUpper() == pais.ToUpper()).ToList();
                return a;
            }
        }

        public List<Estudios> EstudiosInseridosPor (int idUsuario) {
            using (InLockContext ctx = new InLockContext()) {
                return ctx.Estudios.Where(x => x.UsuarioId == idUsuario).ToList();
            }
        }

        public List<Estudios> ListarEstudiosComUsuarios () {
            using (InLockContext ctx = new InLockContext()) {
                var usuarios = ctx.Estudios.Include(x => x.Usuario).ToList();
                foreach(var item in usuarios) {
                    item.Usuario.Senha = null;
                }
                return usuarios;
            }
        }

        public List<Estudios> ListarEstudiosRecentes () {
            using (InLockContext ctx = new InLockContext()) {
                 return ctx.Estudios.Where(x => (DateTime.Today- x.DataCriacao.Date).TotalDays < 10).ToList();
            }
        }
    }
}
