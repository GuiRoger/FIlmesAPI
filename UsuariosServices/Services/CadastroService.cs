using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Interfaces;
using UsuariosDomain.Models;
using UsuariosServices.Interfaces;
using UsuariosServices.Models;

namespace UsuariosServices.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepository _cadRepo;

        public CadastroService(ICadastroRepository cadRepo)
        {
            _cadRepo= cadRepo;
        }
        public async Task<BaseRetorno> CadastrarUsuario(Usuario userData)
        {
            return await _cadRepo.CadastrarUsuario(userData);
        }

    }
}
