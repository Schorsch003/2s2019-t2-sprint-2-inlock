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
    }
}
