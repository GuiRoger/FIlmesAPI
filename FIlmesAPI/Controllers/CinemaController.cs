using AutoMapper;
using FilmesAPI.Controllers;
using FilmesDomain.Models;
using FilmesServices.Interfaces;
using FilmesServices.Models.In.Cinemas;
using FilmesServices.Models.In.Filmes;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMapper _mapper;

        public CinemaController(ICinemaService cinemaService, IMapper mapper)
        {
            _cinemaService = cinemaService;
            _mapper = mapper;
        }

        #region RECUPERAR CINEMA
        [HttpGet]
        public async Task<IEnumerable<Cinema>> RecuperarCinemas() => await _cinemaService.RecuperaCinemas();
        #endregion

        #region CRIAR CINEMA
        [HttpPost]
        public async Task<IActionResult> CriarCinema([FromBody] CreateCinemaDto cinema)
        {

            Cinema cinemaToCreate = _mapper.Map<Cinema>(cinema);

            var bs = await _cinemaService.CriarCinema(cinemaToCreate);


            if (bs.Status)
            {

                var filmeRetorno = await _cinemaService.RecuperarCinemaPorId(Convert.ToInt32(bs.Message));

                return StatusCode(201, filmeRetorno);
            }
            else
            {
                return StatusCode(500, "Houve um erro, contate o adminitrador.");
            }


        }
        #endregion

        #region RECUPERAR CINEMA POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarCinemaPorId(int id)
        {
            var cinema = await _cinemaService.RecuperarCinemaPorId(id);



            if (cinema != null)
            {
                ReadCinemaDto readCinema = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(readCinema);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region ATUALIZAR CINEMA
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCinema([FromRoute] int id, [FromBody] UpdateCinemaDto updatedCinema)
        {
            Cinema cinemaToUpdate = _mapper.Map<Cinema>(updatedCinema);

            var returnFilme = await _cinemaService.AtualizarCinema(cinemaToUpdate, id);

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

        #region DELETAR CINEMA

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCinema([FromRoute] int id)
        {
            var bs = await _cinemaService.DeletarCinema(id);

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
