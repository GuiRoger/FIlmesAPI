using FilmesDbConnection.Context;
using FilmesDomain.Interfaces;
using FilmesDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDbConnection.Repositorys
{
    public class EnderecoRepository:IEnderecoRepository
    {
        public readonly ApiDbContext _context;
        public EnderecoRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> ListarEnderecos()
        {

            var lstCinemas = await _context.Enderecos.ToListAsync();
            return lstCinemas;
        }

        public async Task<BaseRetorno> CriarEndereco(Endereco newEndereco)
        {

            var bs = new BaseRetorno();
            using (var transacao = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Enderecos.AddAsync(newEndereco);
                    await _context.SaveChangesAsync();


                    bs.Message = newEndereco.Id.ToString();
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


        public async Task<Endereco> RecuperarEnderecoPorId(int id)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Endereco> AtualizarEndereco(Endereco updatedEndereco, int id)
        {
            Endereco enderecosParaAtualizar = await _context.Enderecos.FirstOrDefaultAsync(g => g.Id == id);

            if (enderecosParaAtualizar == null)
                return null;

            enderecosParaAtualizar.Logradouro = updatedEndereco.Logradouro;
            enderecosParaAtualizar.Numero = updatedEndereco.Numero;
            enderecosParaAtualizar.Bairro = updatedEndereco.Bairro;       

            await _context.SaveChangesAsync();

            return enderecosParaAtualizar;


        }


        public async Task<BaseRetorno> DeletarEndereco(int id)
        {
            var bs = new BaseRetorno();
            try
            {
                var endereco = await _context.Enderecos.FirstOrDefaultAsync(g => g.Id == id);
                if (endereco == null)
                {

                    bs.Status = false;
                    bs.Message = "Endereço não encontrado.";
                    return bs;
                }

                _context.Enderecos.Remove(endereco);


                await _context.SaveChangesAsync();

                bs.Message = "Endereço deletado com sucesso.";
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
