using FilmesDbConnection.Context;
using FilmesDomain.Interfaces;
using FilmesDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesDbConnection.Repositorys
{
    public class FilmeRepository : IFilmeRepository
    {
        public readonly ApiDbContext _context;
        public FilmeRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filme>> ListarFilmes()
        {

           var lstFilmes = await  _context.Filmes.ToListAsync();
            return lstFilmes;
        }
        
    }
}