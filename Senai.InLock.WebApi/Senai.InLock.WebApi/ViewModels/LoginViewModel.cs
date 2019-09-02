using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.ViewModels {
    public class LoginViewModel {
        [Required(ErrorMessage = "O Email é indispensável")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é essencial para o login")]
        public string Senha { get; set; }
    }
}
