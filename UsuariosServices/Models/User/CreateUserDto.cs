using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosServices.Models.User
{
    public class CreateUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senhas não coincidem")]
        [MinLength(6, ErrorMessage = "O tamanho minimo da senha é 6 digitos.")]        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Senhas não coincidem")]        
        [Compare("Password")]
        [MinLength(6,ErrorMessage ="O tamanho minimo da senha é 6 digitos.")]
        public string RePassword { get; set; }


    }
}
