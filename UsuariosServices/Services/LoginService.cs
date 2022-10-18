using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Interfaces;
using UsuariosDomain.Models.Retornos;
using UsuariosServices.Interfaces;
using UsuariosServices.Models.Request;

namespace UsuariosServices.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _cadLog;
        private IMapper _mapper;
        //private readonly UserManager<IdentityUser<int>> _manager;
        public LoginService(ILoginRepository cadLog, IMapper mapper)
        {
            _cadLog = cadLog;
            _mapper= mapper;
        }
        public async Task<BaseRetorno> Logar(LoginRequest request)
        {
           var rst = await _cadLog.LogarUsuario(request.UserName,request.Password);

            return rst;
        }
    }
}
