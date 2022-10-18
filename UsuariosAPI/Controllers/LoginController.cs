using Microsoft.AspNetCore.Mvc;
using UsuariosServices.Interfaces;
using UsuariosServices.Models.Request;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService=loginService;
        }

        [HttpPost()]
        public async Task<IActionResult> Logar(LoginRequest request)
        {
           var result= await _loginService.Logar(request);

            if (result.Status)
            {
                return Ok(result.Mensagem);
            }

            return Unauthorized(result.Mensagem);
        }


    }
}
