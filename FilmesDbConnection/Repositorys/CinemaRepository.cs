using FilmesDbConnection.Context;
using FilmesDomain.Interfaces;
using FilmesDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDbConnection.Repositorys
{
    public class CinemaRepository : ICinemaRepository
    {
        public readonly ApiDbContext _context;
        public CinemaRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> ListarCinemas(string? nomeDoFilme)
        {

            var lstCinemas = await _context.Cinemas.ToListAsync();
            if (!string.IsNullOrWhiteSpace(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cine in lstCinemas
                                            where cine.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDoFilme)
                                            select cine;
                return query;
            }
            return lstCinemas;
        }

        public async Task<BaseRetorno> CriarCinema(Cinema newCinema)
        {

            var bs = new BaseRetorno();
            using (var transacao = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Cinemas.AddAsync(newCinema);
                    await _context.SaveChangesAsync();


                    bs.Message = newCinema.Id.ToString();
                    bs.Status = true;


                    transacao.Commit();

                    return bs;
                }
                catch (Exception ex)
                {
                    bs.Message = ex.Message;
                    bs.Status = false;

                    await transacao.RollbackAsync();

                    return bs;
                }

            }
        }


        public async Task<Cinema> RecuperarCinemaPorId(int id)
        {


            return await _context.Cinemas.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Cinema> AtualizarCinema(Cinema updateCinema, int id)
        {
            Cinema CinemasParaAtualizar = await _context.Cinemas.FirstOrDefaultAsync(g => g.Id == id);

            if (CinemasParaAtualizar == null)
                return null;

            CinemasParaAtualizar.Nome = updateCinema.Nome;           


            await _context.SaveChangesAsync();

            return CinemasParaAtualizar;


        }


        public async Task<BaseRetorno> DeletarCinema(int id)
        {
            var bs = new BaseRetorno();
            try
            {
                var Cine = await _context.Cinemas.FirstOrDefaultAsync(g => g.Id == id);
                if (Cine == null)
                {

                    bs.Status = false;
                    bs.Message = "Cinema não encontrado.";
                    return bs;
                }

                _context.Cinemas.Remove(Cine);


                await _context.SaveChangesAsync();

                bs.Message = "Cinema deletado com sucesso.";
                bs.Status = true;

                return bs;
            }
            catch (Exception ex)
            {
                bs.Message = ex.Message;
                bs.Status = false;
                return bs;
            }
        }
    }
}
