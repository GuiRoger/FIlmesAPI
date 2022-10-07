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
            Usuario user = _mapper.Map<Usuario>(userInfos);
            var result = await _cadService.CadastrarUsuario(user);

            if (result.Status)
            {
                return Ok(result);

            }
            return BadRequest(result.Mensagem);

        }




    }
}
