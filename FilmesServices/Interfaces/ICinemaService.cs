using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Interfaces
{
    public interface ICinemaService
    {
        public Task<IEnumerable<Cinema>> RecuperaCinemas(string? nomeDoFilme);
        public Task<BaseRetorno> CriarCinema(Cinema cine);
        public Task<Cinema> RecuperarCinemaPorId(int id);
        public Task<Cinema> AtualizarCinema(Cinema cine, int id);
        public Task<BaseRetorno> DeletarCinema(int id);

    }
}
