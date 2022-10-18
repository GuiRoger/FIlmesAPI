using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsuariosServices.Interfaces;
using UsuariosServices.Models;

namespace UsuariosServices.Services
{
    public class TokenService : ITokenService
    {

        public Token Create(IdentityUser<int> user)
        {
            Claim[] userRights = new Claim[]
            {
                new Claim("username",user.UserName),
                new Claim("id",user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("28fd9c30593c2266924b4867837207528c172b557c6abe1053347fbae1d4388f"));

            var credenciais = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: userRights,
                signingCredentials:credenciais,
                expires: DateTime.UtcNow.AddHours(2)
                );


            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString) ;
        }
    }
}
