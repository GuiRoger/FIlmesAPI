using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDbConnection.Context;
using UsuariosDomain.Interfaces;
using UsuariosDomain.Models.Retornos;

namespace UsuariosDbConnection.Repositorys
{
    public class LoginRepository:ILoginRepository
    {
        private readonly ApiUserContextDb _context;
        private readonly SignInManager<IdentityUser<int>> _manager;

        public LoginRepository(SignInManager<IdentityUser<int>> manager)
        {
            _manager = manager;
        }

        public async Task<BaseRetorno> LogarUsuario(string UserName, string Password)
        {

            var resultIdentity = await _manager.PasswordSignInAsync(UserName,Password,false,false);
            var bs = new BaseRetorno();
            if (resultIdentity.Succeeded)
            {
                bs.Mensagem = "Logado com sucesso.";
                bs.Status = true;
                return bs;
            }

            bs.Mensagem = "Falha ao tentar logar.";
            bs.Status = false;
            return bs;
        }
    }
}
