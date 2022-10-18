using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Models.DataBases;
using UsuariosServices.Models.User;

namespace UsuariosServices.Profiles
{
    public class UsuarioProfile :Profile
    {
       public UsuarioProfile()
        {
            CreateMap<CreateUserDto,Usuario>();
            CreateMap<Usuario,ReadUserDto>();
            //CreateMap< IdentityUser<int>,ReadUserDto >();
        }
    }
}
