using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Models;
using UsuariosServices.Models.User;

namespace UsuariosServices.Profiles
{
    public class UsuarioProfile :Profile
    {
       public UsuarioProfile()
        {
            CreateMap<CreateUserDto,Usuario>();
        }
    }
}
