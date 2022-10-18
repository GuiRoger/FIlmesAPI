
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Models.Retornos;

namespace UsuariosDomain.Interfaces
{
    public interface ILoginRepository
    {
        Task<BaseRetorno> LogarUsuario(string UserName,string Password); 

    }
}

