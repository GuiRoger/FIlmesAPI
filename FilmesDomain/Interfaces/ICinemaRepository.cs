using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDomain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<IEnumerable<Cinema>> ListarCinemas();
        public Task<BaseRetorno> CriarCinema(Cinema newCinema);
        public Task<Cinema> RecuperarCinemaPorId(int id);
        public Task<Cinema> AtualizarCinema(Cinema updateCinema, int id);
        public Task<BaseRetorno> DeletarCinema(int id);
    }
}
