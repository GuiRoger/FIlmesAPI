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
    public class EnderecoService : IEnderecoService
    {

        private readonly IEnderecoRepository _endRepo;

        public EnderecoService(IEnderecoRepository endRepo)
        {
            _endRepo = endRepo;
        }

        public async Task<IEnumerable<Endereco>> ListarEnderecos() => await _endRepo.ListarEnderecos();


        public async Task<BaseRetorno> CriarEndereco(Endereco endereco)
        {
            return await _endRepo.CriarEndereco(endereco);
        }

        public async Task<Endereco> RecuperarEnderecoPorId(int id) => await _endRepo.RecuperarEnderecoPorId(id);


        public async Task<Endereco> AtualizarEndereco(Endereco endereco, int id)
        {

            return await _endRepo.AtualizarEndereco(endereco, id);
        }


        public async Task<BaseRetorno> DeletarEndereco(int id) => await _endRepo.DeletarEndereco(id);
    }
}
