using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Interfaces;
using UsuariosDomain.Models;
using UsuariosServices.Interfaces;
using UsuariosServices.Models;
using UsuariosServices.Models.User;

namespace UsuariosServices.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepository _cadRepo;
        private IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _manager;

        public CadastroService(ICadastroRepository cadRepo, IMapper mapper, UserManager<IdentityUser<int>> manager)
        {
            _cadRepo= cadRepo;
            _mapper=mapper;
            _manager=manager;
        }
        public async Task<BaseRetorno> CadastrarUsuario(CreateUserDto userData)
        {
            Usuario user = _mapper.Map<Usuario>(userData);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);

            return await _cadRepo.CadastrarUsuario(userIdentity, userData.Password);
        } 
        
        public async Task<IdentityUser<int>> RecuperaUsuario(int id)
        {
            var user = await _cadRepo.RecuperaUsuario(id);
            if (user != null)
            {
               
                return user;

            }

            return null;
        }

    }
}
