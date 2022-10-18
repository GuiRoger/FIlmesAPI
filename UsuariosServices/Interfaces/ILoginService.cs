using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Models.Retornos;
using UsuariosServices.Models.Request;

namespace UsuariosServices.Interfaces
{
    public interface ILoginService
    {
         Task<BaseRetorno> Logar(LoginRequest request);
    }
}
