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
    public class SessaoRepository : ISessaoRepository
    {
        public readonly ApiDbContext _context;
        public SessaoRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sessao>> ListarSessoes()
        {

            var lstSessao = await _context.Sessao.ToListAsync();
            return lstSessao;
        }

        public async Task<BaseRetorno> CriarSessao(Sessao newSessao)
        {

            var bs = new BaseRetorno();
            using (var transacao = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    newSessao.Filme = await _context.Filmes.FirstOrDefaultAsync(f=>f.Id == newSessao.FilmeId);
                    newSessao.Cinema = await _context.Cinemas.FirstOrDefaultAsync(f=>f.Id == newSessao.CinemaId);

                    if(newSessao.Filme==null && newSessao.Cinema == null)
                    {
                        bs.Message = "Filme ou Cinema não encontrado";
                        bs.Status = false;
                        return bs;
                    }


                    await _context.Sessao.AddAsync(newSessao);
                    await _context.SaveChangesAsync();


                    bs.Message = newSessao.Id.ToString();
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


        public async Task<Sessao> RecuperarSessaoPorId(int id)
        {
            return await _context.Sessao.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Sessao> AtualizarSessao(Sessao update, int id)
        {
            Sessao SessaoParaAtualizar = await _context.Sessao.FirstOrDefaultAsync(g => g.Id == id);

            if (SessaoParaAtualizar == null)
                return null;

            SessaoParaAtualizar.CinemaId = update.CinemaId;
            SessaoParaAtualizar.FilmeId = update.FilmeId;
            SessaoParaAtualizar.HorarioDeEncerramento = update.HorarioDeEncerramento;


            await _context.SaveChangesAsync();

            return SessaoParaAtualizar;


        }


        public async Task<BaseRetorno> DeletarSessao(int id)
        {
            var bs = new BaseRetorno();
            try
            {
                var Sessao = await _context.Sessao.FirstOrDefaultAsync(g => g.Id == id);
                if (Sessao == null)
                {

                    bs.Status = false;
                    bs.Message = "Sessao não encontrado.";
                    return bs;
                }

                _context.Sessao.Remove(Sessao);


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
