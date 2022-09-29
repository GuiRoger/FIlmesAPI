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

        public async Task<IEnumerable<Filme>> RecuperaFilmes() => await _filmeRepo.ListarFilmes();
        

        public async Task<BaseRetorno> CriarFilme(CreateFilmeDto filme)
        {
            var newFilme = new Filme{
                Diretor = filme.Diretor,
                Duracao = filme.Duracao,
                Genero = filme.Genero,
                Titulo = filme.Titulo,
            
            };

            return await _filmeRepo.CriarFilmes(newFilme);
        }

        public async Task<Filme> RecuperarFilmePorId(int id) => await _filmeRepo.RecuperarFilmePorId(id);


        public async Task<Filme> AtualizarFilme(UpdateFilmeDto filme,int id)
        {
            var updatedFilme = new Filme
            {
                Diretor = filme.Diretor,
                Duracao = filme.Duracao,
                Genero = filme.Genero,
                Titulo = filme.Titulo,

            };
            return await _filmeRepo.AtualizarFilme(updatedFilme,id);
        }


        public async Task<BaseRetorno> DeletarFilme(int id) => await _filmeRepo.DeletarFilme(id);
    }
}
