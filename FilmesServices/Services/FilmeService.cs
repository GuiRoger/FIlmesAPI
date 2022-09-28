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
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepo;

        public FilmeService(IFilmeRepository filmeRepo)
        {
            _filmeRepo = filmeRepo;
        }

        public async Task<IEnumerable<Filme>> RecuperaFilmes()
        {
           return await _filmeRepo.ListarFilmes();
        }
    }
}
