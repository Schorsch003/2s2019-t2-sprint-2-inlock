using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories {
    public class UsuarioRepository {

        public Usuarios BuscarPorEmailESenha(LoginViewModel login) {
            using (InLockContext ctx = new InLockContext()) {
                var usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if(usuario == null) {
                    return null;
                }
                return usuario;
            }
        }

        public List<Usuarios> Listar () {
            using (InLockContext ctx = new InLockContext()) {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
