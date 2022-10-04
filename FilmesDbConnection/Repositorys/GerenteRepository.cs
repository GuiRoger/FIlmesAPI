using FilmesDbConnection.Context;
using FilmesDomain.Models;
using GerentesDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerentesDbConnection.Repositorys
{
    public class GerenteRepository : IGerenteRepository
    {
        public readonly ApiDbContext _context;
        public GerenteRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gerente>> ListarGerentes()
        {

            var lstGerentes = await _context.Gerentes.ToListAsync();
            return lstGerentes;
        }

        public async Task<BaseRetorno> CriarGerentes(Gerente newGerente)
        {

            var bs = new BaseRetorno();
            using (var transacao = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Gerentes.AddAsync(newGerente);
                    await _context.SaveChangesAsync();


                    bs.Message = newGerente.Id.ToString();
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


        public async Task<Gerente> RecuperarGerentePorId(int id)
        {
            return await _context.Gerentes.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Gerente> AtualizarGerente(Gerente update, int id)
        {
            Gerente GerenteParaAtualizar = await _context.Gerentes.FirstOrDefaultAsync(g => g.Id == id);

            if (GerenteParaAtualizar == null)
                return null;

            GerenteParaAtualizar.Name = update.Name;
           

            await _context.SaveChangesAsync();

            return GerenteParaAtualizar;


        }


        public async Task<BaseRetorno> DeletarGerente(int id)
        {
            var bs = new BaseRetorno();
            try
            {
                var Gerente = await _context.Gerentes.FirstOrDefaultAsync(g => g.Id == id);
                if (Gerente == null)
                {

                    bs.Status = false;
                    bs.Message = "Gerente não encontrado.";
                    return bs;
                }

                _context.Gerentes.Remove(Gerente);


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
