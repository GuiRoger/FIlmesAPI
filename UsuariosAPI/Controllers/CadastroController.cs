using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsuariosDomain.Models;
using UsuariosServices.Interfaces;
using UsuariosServices.Models.User;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        public readonly ICadastroService _cadService;
        public readonly IMapper _mapper;
        public CadastroController(ICadastroService cadService, IMapper mapper)
        {
            _cadService = cadService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task< IActionResult> CadastrarUsuario(CreateUserDto userInfos)
        {
          
            var result = await _cadService.CadastrarUsuario(userInfos);

            if (result.Status)
            {
                return Ok(result);

            }
            return BadRequest(result.Mensagem);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var searchUser = await _cadService.RecuperaUsuario(id);

            if (searchUser == null)
            {
                return NotFound("Nenhum usuário encontrado com esse Id.Tente com outro Id.");
            }
            
            return Ok(searchUser);
        }




    }
}
