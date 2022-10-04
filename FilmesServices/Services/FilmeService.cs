using FilmesDomain.Interfaces;
using FilmesDomain.Models;
using FilmesServices.Interfaces;
using FilmesServices.Models.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepo;

        public FilmeService(IFilmeRepository filmeRepo)
        {
            _filmeRepo = filmeRepo;
        }

        public async Task<IEnumerable<Filme>> RecuperaFilmes(int? classificacaoEtaria) => await _filmeRepo.ListarFilmes(classificacaoEtaria);
        

        public async Task<BaseRetorno> CriarFilme(Filme filme)
        {
            return await _filmeRepo.CriarFilmes(filme);
        }

        public async Task<Filme> RecuperarFilmePorId(int id) => await _filmeRepo.RecuperarFilmePorId(id);


        public async Task<Filme> AtualizarFilme(Filme filme,int id)
        {
          
            return await _filmeRepo.AtualizarFilme(filme, id);
        }


        public async Task<BaseRetorno> DeletarFilme(int id) => await _filmeRepo.DeletarFilme(id);
    }
}
