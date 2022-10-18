using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosDomain.Models.DataBases;

namespace UsuariosDbConnection.Context
{
    public class ApiUserContextDb : IdentityDbContext<IdentityUser<int>, IdentityRole<int>,int>
    {

        public ApiUserContextDb(DbContextOptions<ApiUserContextDb> opt) : base(opt)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
