using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Interfaces;
using FilmesServices.Models.In.Gerentes;

using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : Controller
    {
        private readonly IGerenteService _gerenteService;
        private readonly IMapper _mapper;

        public GerenteController(IGerenteService gerenteService, IMapper mapper)
        {
            _gerenteService = gerenteService;
            _mapper = mapper;
        }

        

        #region CRIAR FILME
        [HttpPost]
        public async Task<IActionResult> CriarGerente([FromBody] CreateGerenteDto Gerente)
        {

            Gerente GerenteToCreate = _mapper.Map<Gerente>(Gerente);

            var bs = await _gerenteService.CriarGerente(GerenteToCreate);


            if (bs.Status)
            {

                var filmeRetorno = await _gerenteService.RecuperarGerentePorId(Convert.ToInt32(bs.Message));

                return StatusCode(201, filmeRetorno);
            }
            else
            {
                return StatusCode(500, "Houve um erro, contate o adminitrador.");
            }


        }
        #endregion

        #region RECUPERAR Gerente POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarGerentePorId(int id)
        {
            var Gerente = await _gerenteService.RecuperarGerentePorId(id);



            if (Gerente != null)
            {
                ReadGerenteDto readGerente = _mapper.Map<ReadGerenteDto>(Gerente);
                return Ok(readGerente);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        //#region ATUALIZAR Gerente
        //[HttpPut("{id}")]
        //public async Task<IActionResult> AtualizarGerente([FromRoute] int id, [FromBody] UpdateGerenteDto updatedGerente)
        //{
        //    Gerente GerenteToUpdate = _mapper.Map<Gerente>(updatedGerente);

        //    var returnFilme = await _gerenteService.AtualizarGerente(GerenteToUpdate, id);

        //    if (returnFilme != null)
        //    {
        //        return Ok(returnFilme);

        //    }
        //    else
        //    {
        //        return NotFound("Filme não encontrado.");

        //    }
        //}
        //#endregion

        #region DELETAR FILME

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarGerente([FromRoute] int id)
        {
            var bs = await _gerenteService.DeletarGerente(id);

            if (bs.Status)
            {
                return Ok(bs.Message);

            }
            else
            {
                return NotFound(bs.Message);

            }

        }

        #endregion
    }
}
