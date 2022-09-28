using FilmesDomain.Models;
using FilmesServices.Interfaces;
using FilmesServices.Models.In;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("RecuperarFilmes")]
        public async Task<IEnumerable<Filme>> RecuperarFilmes() =>  await _filmService.RecuperaFilmes();


        
    }
}
