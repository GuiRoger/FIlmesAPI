
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Models;
using UsuariosServices.Models.User;

namespace UsuariosServices.Interfaces
{
    public interface ICadastroService
    {
        public Task<BaseRetorno> CadastrarUsuario(CreateUserDto userData); 
        public Task<IdentityUser<int>> RecuperaUsuario(int id); 
    }
}
