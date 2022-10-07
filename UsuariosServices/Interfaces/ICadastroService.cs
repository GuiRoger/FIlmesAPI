
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
        public Task<BaseRetorno> CadastrarUsuario(Usuario userData); 
    }
}
