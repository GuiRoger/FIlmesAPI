using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UsuariosDbConnection.Context;
using UsuariosDomain.Interfaces;
using UsuariosDomain.Models;

namespace UsuariosDbConnection.Repositorys
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly ApiUserContextDb _context;

        public CadastroRepository(ApiUserContextDb context)
        {
            _context = context;
        }
        public async Task<BaseRetorno> CadastrarUsuario(Usuario userData)
        {
            var exist = await _context.Usuarios.FirstOrDefaultAsync(g=> g.Id == userData.Id);
            var bs = new BaseRetorno();
            if (exist != null)
            {

                bs.Mensagem = "Já existe um usuario com esses dados.";
                bs.Status = false;
                return bs;
                
            }

            await _context.Usuarios.AddAsync(userData);
            await _context.SaveChangesAsync();

            bs.Mensagem = "Cadastrado com sucesso.";
            bs.Status = true;
            return bs;

        }



    }
}
