﻿using FilmesDbConnection.Context;
using FilmesDomain.Interfaces;
using FilmesDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<BaseRetorno> CriarFilmes(Filme newFilme)
        {

            var bs = new BaseRetorno();
            using (var transacao = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                  await _context.Filmes.AddAsync(newFilme);
                    await _context.SaveChangesAsync();


                    bs.Message = newFilme.Id.ToString();
                    bs.Status = true;


                     transacao.Commit();

                    return bs;
                }
                catch(Exception ex)
                {
                    bs.Message = ex.Message;
                    bs.Status = false;

                    await transacao.RollbackAsync();

                    return bs;
                }              
             
            }
        }


        public async Task<Filme> RecuperarFilmePorId(int id)
        {
            return await _context.Filmes.FirstOrDefaultAsync(g=>g.Id == id);
        }




    }
}