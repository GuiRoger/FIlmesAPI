using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UsuariosDbConnection.Context;
using UsuariosDomain.Interfaces;
using UsuariosDomain.Models.Retornos;

namespace UsuariosDbConnection.Repositorys
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly ApiUserContextDb _context;
        private readonly UserManager<IdentityUser<int>> _manager;

        public CadastroRepository(ApiUserContextDb context, UserManager<IdentityUser<int>> manager)
        {
            _context = context;
            _manager = manager;
        }
        public async Task<BaseRetorno> CadastrarUsuario(IdentityUser<int> userIdentity, string password)
        {
            var exist = await _manager.Users.FirstOrDefaultAsync(g=>g.Email == userIdentity.Email);
            var bs = new BaseRetorno();
            if (exist != null)
            {

                bs.Mensagem = "Já existe um usuario com esse Email.";
                bs.Status = false;
                return bs;
                
            }

            var resultRegister = await _manager.CreateAsync(userIdentity,password);

            if (resultRegister.Succeeded)
            {
                bs.Mensagem = "Cadastrado com sucesso.";
                bs.Status = true;
                return bs;
            }
                

            bs.Mensagem = "Erro ao Cadastrar Usuário.";
            bs.Status = false;
            return bs;

        }

        public async Task<IdentityUser<int>> RecuperaUsuario(int id)
        {

            return await _manager.Users.FirstOrDefaultAsync(g => g.Id == id);
        }

        



    }
}
