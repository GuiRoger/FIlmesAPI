using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDomain.Interfaces
{
    public interface IFilmeRepository
    {
        public Task<IEnumerable<Filme>> ListarFilmes();
        public Task<BaseRetorno> CriarFilmes(Filme newFilme);
        public Task<Filme> RecuperarFilmePorId(int id);
        public Task<Filme> AtualizarFilme(Filme update,int id);
        public Task<BaseRetorno> DeletarFilme(int id);
    }
}
