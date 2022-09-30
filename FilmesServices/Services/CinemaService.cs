using FilmesDomain.Interfaces;
using FilmesDomain.Models;
using FilmesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cineRepo;

        public CinemaService(ICinemaRepository cineRepo)
        {
            _cineRepo = cineRepo;
        }

        public async Task<IEnumerable<Cinema>> RecuperaCinemas() => await _cineRepo.ListarCinemas();


        public async Task<BaseRetorno> CriarCinema(Cinema cinema)
        {
            return await _cineRepo.CriarCinema(cinema);
        }

        public async Task<Cinema> RecuperarCinemaPorId(int id) => await _cineRepo.RecuperarCinemaPorId(id);


        public async Task<Cinema> AtualizarCinema(Cinema cinema, int id)
        {

            return await _cineRepo.AtualizarCinema(cinema, id);
        }


        public async Task<BaseRetorno> DeletarCinema(int id) => await _cineRepo.DeletarCinema(id);


    }
}
