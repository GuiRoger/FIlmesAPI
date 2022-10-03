using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Interfaces;
using FilmesServices.Models.In.Filmes;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FilmesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmesController : Controller
    {
        private readonly IFilmeService _filmService;
        private readonly IMapper _mapper;

        public FilmesController(IFilmeService filmService, IMapper mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        #region RECUPERAR FILME
        [HttpGet]
        public async Task<IEnumerable<Filme>> RecuperarFilmes() => await _filmService.RecuperaFilmes(); 
        #endregion

        #region CRIAR FILME
        [HttpPost("CriarFilme")]
        public async Task<IActionResult> CriarFilme([FromBody] CreateFilmeDto filme)
        {

            Filme filmeToCreate = _mapper.Map<Filme>(filme);

            var bs = await _filmService.CriarFilme(filmeToCreate);


            if (bs.Status)
            {

                var filmeRetorno = await _filmService.RecuperarFilmePorId(Convert.ToInt32(bs.Message));

                return StatusCode(201, filmeRetorno);
            }
            else
            {
                return StatusCode(500, "Houve um erro, contate o adminitrador.");
            }


        } 
        #endregion

        #region RECUPERAR FILME POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarFilmePorId(int id)
        {
            var filme = await _filmService.RecuperarFilmePorId(id);

            if (filme != null)
            {
                ReadFilmeDto readFilme = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(readFilme);
            }
            else
            {
                return NotFound();
            }
        } 
        #endregion

        #region ATUALIZAR FILME
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFilme([FromRoute] int id, [FromBody] UpdateFilmeDto updatedFilme)
        {
            Filme filmeToUpdate = _mapper.Map<Filme>(updatedFilme);

            var returnFilme = await _filmService.AtualizarFilme(filmeToUpdate, id);

            if (returnFilme != null)
            {
                return Ok(returnFilme);

            }
            else
            {
                return NotFound("Filme não encontrado.");

            }
        } 
        #endregion

        #region DELETAR FILME

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFilme([FromRoute] int id)
        {
            var bs = await _filmService.DeletarFilme(id);

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
