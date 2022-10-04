using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Interfaces;
using FilmesServices.Models.In.Gerentes;
using FilmesServices.Models.In.Sessoes;
using GerentesServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;
        private readonly IMapper _mapper;

        public SessaoController(ISessaoService sessaoService, IMapper mapper)
        {
            _sessaoService = sessaoService;
            _mapper = mapper;
        }



        #region CRIAR Sessao
        [HttpPost]
        public async Task<IActionResult> CriarSessao([FromBody] CreateSessaoDto Sessao)
        {

            Sessao SessaoToCreate = _mapper.Map<Sessao>(Sessao);

            var bs = await _sessaoService.CriarSessao(SessaoToCreate);


            if (bs.Status)
            {

                var filmeRetorno = await _sessaoService.RecuperarSessaoPorId(Convert.ToInt32(bs.Message));

                return StatusCode(201, filmeRetorno);
            }
            else
            {
                return StatusCode(500, "Houve um erro, contate o adminitrador.");
            }


        }
        #endregion

        #region Listar Sessoes
        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperaSessaoPorId(int id) 
        {
            var Sessao = await _sessaoService.RecuperarSessaoPorId(id);



            if (Sessao != null)
            {
                ReadSessaoDto readGerente = _mapper.Map<ReadSessaoDto>(Sessao);
                return Ok(readGerente);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion
    }
}
