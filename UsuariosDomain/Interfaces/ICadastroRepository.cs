
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Models;


namespace UsuariosDomain.Interfaces
{
    public interface ICadastroRepository
    {

        public Task<BaseRetorno> CadastrarUsuario(Usuario userData);
    }
}
