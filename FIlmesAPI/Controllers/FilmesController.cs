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
        public async Task<IActionResult> CriarFilme([FromBody] FilmeDto filme)
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




    }
}
