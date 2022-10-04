using FilmesDbConnection.Context;
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

        public async Task<IEnumerable<Filme>> ListarFilmes(int? classificacaoEtaria)
        {
            List<Filme> lstFilmes;
            if (classificacaoEtaria != null)
            {

                lstFilmes = await  _context.Filmes.Where(filme=> filme.ClassificacaoEtaria <= classificacaoEtaria).ToListAsync();
            }
            else
            {
                lstFilmes = await _context.Filmes.ToListAsync();
            }

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

        public  async Task<Filme> AtualizarFilme(Filme update,int id)
        {
            Filme filmeParaAtualizar = await _context.Filmes.FirstOrDefaultAsync(g=>g.Id == id);
            
            if (filmeParaAtualizar == null)
                return null;

            filmeParaAtualizar.Titulo = update.Titulo;
            filmeParaAtualizar.Duracao = update.Duracao;
            filmeParaAtualizar.Diretor = update.Diretor;
            filmeParaAtualizar.Genero = update.Genero;

                await _context.SaveChangesAsync();

            return filmeParaAtualizar;           
            

        }

        
        public  async Task<BaseRetorno> DeletarFilme(int id)
        {
            var bs = new BaseRetorno();
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(g => g.Id == id);
                if (filme == null)
                {

                    bs.Status = false;
                    bs.Message = "Filme não encontrado.";
                    return bs;
                }

                _context.Filmes.Remove(filme);


                await _context.SaveChangesAsync();

                bs.Message = "Deletado com sucesso.";
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