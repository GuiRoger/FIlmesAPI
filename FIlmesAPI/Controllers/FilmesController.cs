using FilmesDomain.Models;
using FilmesServices.Interfaces;
using FilmesServices.Models.In;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FIlmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : Controller
    {
        private readonly IFilmeService _filmService;

        public FilmesController(IFilmeService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IEnumerable<Filme>> RecuperarFilmes() => await _filmService.RecuperaFilmes();

        [HttpPost("CriarFilme")]
        public async Task<IActionResult> CriarFilme([FromBody] CreateFilmeDto filme)
        {

            var bs = await _filmService.CriarFilme(filme);

            if (bs.Status)
            {
                return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = Convert.ToInt32(bs.Message) });
            }
            else
            {
                return StatusCode(500, "Houve um erro, contate o adminitrador.");
            }


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarFilmePorId(int id)
        {
            var filme = await _filmService.RecuperarFilmePorId(id);

            if (filme != null)
            {
                return Ok(filme);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFilme([FromRoute] int id, [FromBody] UpdateFilmeDto updatedFilme)
        {
            var returnFilme = await _filmService.AtualizarFilme(updatedFilme, id);

            if (returnFilme != null)
            {
                return Ok(returnFilme);

            }
            else
            {
                return NotFound("Filme não encontrado.");

            }
            
        }

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



    }
}
